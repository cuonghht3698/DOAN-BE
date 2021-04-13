using Device_BE.Database;
using Device_BE.DTO;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;

namespace Device_BE.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public CartsController(QLPhoneContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetCartId/{Id}")]
        public Dmcart GetCartId(Guid Id)
        {

            var data = _context.Dmcart.Where(x => x.Id == Id).Include(x => x.TrangThai).FirstOrDefault();
            return data;
        }

        [HttpGet]
        [Route("CheckCart")]
        public IEnumerable<Dmcart> CheckCart(Guid UserId, string ClientId)
        {
            Guid TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;

            var data = _context.Dmcart.Where(x => x.UserId == UserId && x.TrangThaiId == TrangThaiId);
            var user = _context.Htuser.Find(UserId);
            if (user.Username == "khachhang")
            {
                data = data.Where(x => x.ClientId == ClientId);
            }
            return data;
        }

        [HttpGet]
        [Route("ShowShoppingCart")]
        public ActionResult ShowShoppingCart(Guid UserId, string ClientId)
        {
            Guid TT = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;
            var data = _context.Dmcart.Where(x => x.TrangThaiId == TT && x.UserId == UserId).ToList();
            var user = _context.Htuser.Find(UserId);
            if (user.Username == "khachhang")
            {
                data = data.Where(x => x.ClientId == ClientId).ToList();
            }
            var query = from d in data
                        join cd in _context.DmcartDetail on d.Id equals cd.CartId
                        join sp in _context.DmsanPham on cd.SanPhamId equals sp.Id
                        join op in _context.OptionSanPham on cd.OptionId equals op.Id
                        select new { d, cd, sp, op };

            var list = query.Select(x => new
            {

                IdCartDetail = x.cd.Id,
                TenSp = x.sp.Ten,
                SoLuong = x.cd.SoLuong,
                CauHinh = x.op.Ram + " - " + x.op.Rom,
                Gia = x.cd.Gia,
                Anh = x.sp.ImageUrl

            });
            return Ok(list);
        }
        [HttpGet]
        [Route("ShowShoppingById")]
        public ActionResult ShowShoppingCartById(Guid Id)
        {
            var data = _context.Dmcart.Where(x => x.Id == Id).ToList();

            var query = from d in data
                        join cd in _context.DmcartDetail on d.Id equals cd.CartId
                        join sp in _context.DmsanPham on cd.SanPhamId equals sp.Id
                        join op in _context.OptionSanPham on cd.OptionId equals op.Id
                        select new { d, cd, sp, op };

            var list = query.Select(x => new
            {

                IdCartDetail = x.cd.Id,
                TenSp = x.sp.Ten,
                SoLuong = x.cd.SoLuong,
                CauHinh = x.op.Ram + " - " + x.op.Rom,
                Gia = x.cd.Gia,
                Anh = x.sp.ImageUrl,
                IdOption = x.op.Id
            });
            return Ok(list);
        }
        [HttpPost]
        [Route("getPage")]
        public IEnumerable<CartModel> getPage(SearchModel model)
        {
            var data = _context.Dmcart.Include(x => x.TrangThai).Where(x => model.TuNgay <= x.ThoiGianTao && x.ThoiGianTao <= model.DenNgay).ToList();
            if (!String.IsNullOrEmpty(model.sSearch))
            {
                data = data.Where(x => x.Sdt.Contains(model.sSearch)).ToList();
            }
            if (model.TrangThaiId != null)
            {
                data = data.Where(x => x.TrangThaiId == model.TrangThaiId).ToList();
            }
            data = data.Skip((model.pageIndex * model.pageSize)).Take(model.pageSize).OrderByDescending(x => x.TrangThaiId).ToList();
            IEnumerable<CartModel> cart;
            cart = data.Select(x =>
            {
                var r = x.CopyAs<CartModel>();
                r.TrangThai = x.TrangThai.Ten;
                r.MaTrangThai = x.TrangThai.MaTuDien;
                return r;
            });
            return cart;
        }
        [HttpGet]
        [Route("GetCartByUserId/{Id}")]
        public ActionResult GetCartByUserId(Guid Id)
        {
            var data = _context.Dmcart.Where(x => x.UserId == Id).Include(x => x.TrangThai).Include(x => x.NhanVien).ToList();
            var list = data.Select(x => new
            {
                x.ThoiGianTao,
                x.TinNhan,
                NhanVien = x.NhanVien != null ? x.NhanVien.HoTen : "",
                TenTrangThai = x.TrangThai.Ten,
                MaTrangThai = x.TrangThai.MaTuDien,
                x.TongTien,
                x.DiaChi,
                x.Id,
                x.Sdt,
            });
            return Ok(list);
        }
        [HttpPost]
        [Route("CreateNewCart")]
        public Dmcart CreateNewCart(CartModel cart)
        {
            cart.Id = Guid.NewGuid();
            cart.ThoiGianTao = DateTime.Now;
            var data = cart.CopyAs<Dmcart>();
            data.LoaiGiaoDichId = _context.CmtuDien.Where(x => x.MaTuDien == cart.LoaiGiaoDich).FirstOrDefault().Id;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == cart.TrangThai).FirstOrDefault().Id;
            _context.Dmcart.Add(data);
            _context.SaveChanges();
            return data;
        }

        [HttpPost]
        [Route("ChangTrangThai")]
        public ActionResult ChangTrangThai(CartModel cart)
        {
            var data = cart.CopyAs<Dmcart>();
            data.NhanVienId = cart.NhanVienId;
            data.LoaiGiaoDichId = _context.CmtuDien.Where(x => x.MaTuDien == cart.LoaiGiaoDich).FirstOrDefault().Id;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == cart.TrangThai).FirstOrDefault().Id;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("GiaoHang")]
        public ActionResult GiaoHang(GiaoHangModel cart)
        {
           
            var data = _context.Dmcart.Find(cart.Id);
            data.NgayHoanThanh = DateTime.Now;
            data.NhanVienId = cart.NhanVienId;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoHang").FirstOrDefault().Id;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("HuyDon")]
        public ActionResult HuyDon(GiaoHangModel cart)
        {

            var data = _context.Dmcart.Find(cart.Id);
            data.NgayHoanThanh = DateTime.Now;
            data.NhanVienId = cart.NhanVienId;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DaHuy").FirstOrDefault().Id;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("HoanThanh")]
        public ActionResult HoanThanh(GiaoHangModel cart)
        {

            var data = _context.Dmcart.Find(cart.Id);
            data.NgayHoanThanh = DateTime.Now;
            data.NhanVienId = cart.NhanVienId;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DaHoanThanh").FirstOrDefault().Id;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("TaoHoaDon")]
        public ActionResult TaoHoaDon(TaoHoaDonModel hoadon)
        {
            if (hoadon.DSSanPham.Count == 0)
            {
                return BadRequest();
            }
            if (String.IsNullOrEmpty(hoadon.HoTen))
            {
                return BadRequest();

            }
            if (String.IsNullOrEmpty(hoadon.DiaChi))
            {
                return BadRequest();

            }
            if (String.IsNullOrEmpty(hoadon.Sdt))
            {
                return BadRequest();

            }

            Guid IdTrangThai = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;
            var data = hoadon.CopyAs<Dmcart>();
            data.Id = Guid.NewGuid();
            data.TrangThaiId = IdTrangThai;
            data.ThoiGianTao = DateTime.Now;
            data.TinNhan = "Khách hàng " + data.HoTen;
            _context.Dmcart.Add(data);
            foreach (var item in hoadon.DSSanPham)
            {
                var detail = item.CopyAs<DmcartDetail>();
                detail.Id = Guid.NewGuid();
                detail.ThoiGianTao = DateTime.Now;
                detail.CartId = data.Id;
                _context.DmcartDetail.Add(detail);
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
