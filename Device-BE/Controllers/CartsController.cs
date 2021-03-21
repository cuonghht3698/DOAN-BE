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

            var data = _context.Dmcart.Where(x => x.Id == Id).Include(x=>x.TrangThai).FirstOrDefault();
            return data;
        }

        [HttpGet]
        [Route("CheckCart/{UserId}")]
        public IEnumerable<Dmcart> CheckCart(Guid UserId)
        {
            Guid TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;

            var data = _context.Dmcart.Where(x => x.UserId == UserId && x.TrangThaiId == TrangThaiId);
            return data;
        }

        [HttpGet]
        [Route("ShowShoppingCart/{UserId}")]
        public ActionResult ShowShoppingCart(Guid UserId)
        {
            Guid TT = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;
            var data = _context.Dmcart.Where(x => x.TrangThaiId == TT &&  x.UserId == UserId).ToList();

            var query = from d in data
                       join cd in _context.DmcartDetail on d.Id equals cd.CartId
                       join sp in _context.DmsanPham on cd.SanPhamId equals sp.Id
                       join op in _context.OptionSanPham on cd.OptionId equals op.Id
                        select new { d, cd, sp, op };

            var list = query.Select(x => new { 
              
                    IdCartDetail = x.cd.Id,
                    TenSp = x.sp.Ten,
                    SoLuong = x.cd.SoLuong,
                    CauHinh = x.op.Ram + " - "+ x.op.Rom,
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

            var list = query.Select(x => new {

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
        [Route("getPage")]
        [Obsolete]
        public ActionResult getPage(Guid UserId,Guid IdTrangThai, int PageIndex, int PageSize)
        {
            var data = _context.Database.ExecuteSqlRaw(@"exec GetCart ''");
            return Ok(data);
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
                NhanVien = x.NhanVien!= null ? x.NhanVien.HoTen : "",
                TenTrangThai =  x.TrangThai.Ten,
                MaTrangThai = x.TrangThai.MaTuDien,
                x.TongTien,
                x.DiaChi,
                x.Id
            });
            return Ok(list);
        }
        [HttpPost]
        [Route("CreateNewCart")]
        public Dmcart CreateNewCart(CartModel cart)
        {
            cart.Id = Guid.NewGuid();
            
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
    }
}
