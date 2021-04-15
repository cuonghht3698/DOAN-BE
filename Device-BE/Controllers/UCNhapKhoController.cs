using Device_BE.Database.NhapKho;
using Device_BE.Function;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;
using Microsoft.EntityFrameworkCore;
namespace Device_BE.Controllers
{
    [Route("api/nhapkhos")]
    [ApiController]
    public class UCNhapKhoController : ControllerBase
    {
        private readonly QLPhoneContext _context;

        public UCNhapKhoController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("getpage")]
        public ListView<UCNhapKhoModel> getPage(SearchModel model)
        {
            ListView<UCNhapKhoModel> results = new ListView<UCNhapKhoModel>();
            var data = _context.UcnhapKho.Include(x => x.IdTrangThaiNavigation).Include(x => x.IdNguoiTaoNavigation).ToList();
            if (model.sSearch.IsNullOrEmpty())
            {
                data = data.Where(x => x.SoHd == model.sSearch).ToList();
            }
            if (model.TuNgay != null)
            {
                data = data.Where(x => x.NgayTao >= model.TuNgay).ToList();
            }
            if (model.DenNgay != null)
            {
                data = data.Where(x => x.NgayTao <= model.DenNgay).ToList();
            }
            if (model.IdNguoiTao != null)
            {
                data = data.Where(x => x.IdNguoiTao == model.IdNguoiTao).ToList();
            }
            if (model.TrangThaiId != null)
            {
                data = data.Where(x => x.IdTrangThai == model.TrangThaiId).ToList();
            }

            results.total = data.Count();
            data = data.Skip(model.pageIndex * model.pageSize).Take(model.pageSize).ToList();
            results.List = data.Select(x => new UCNhapKhoModel
            { 
                Id = x.Id,
                GhiChu = x.GhiChu,
                NgayTao = x.NgayTao,
                NguoiTao = x.IdNguoiTaoNavigation.HoTen,
                TrangThai = x.IdTrangThaiNavigation.Ten,
                NgayHoanThanh = x.NgayHoanThanh,
                Ten = x.Ten,
                SoHd = x.SoHd,
                TongTien = x.TongTien,
                IdNguoiTao = x.IdNguoiTao                
            }).OrderByDescending(x => x.NgayTao);
            return results;
        }


        [HttpGet]
        [Route("chitiet")]
        public IEnumerable<UCChiTietNhapKhoModel> getByIdNhapKho(Guid IdNhapKho)
        {
            IEnumerable<UCChiTietNhapKhoModel> result;
            var data = _context.UcchiTietNhapKho.Where(x => x.IdNhapKho == IdNhapKho).ToList();
            if (data.Count == 0)
            {
                return null;
            }
            result = data.Select(x => x.CopyAs<UCChiTietNhapKhoModel>());
            return result;
        }

        [HttpPost]
        public ActionResult Create(UCNhapKhoModel model)
        {
            if (model.DSChitiet.Count() == 0)
            {
                return BadRequest();
            }

            UcnhapKho nhapkho = new UcnhapKho();
            nhapkho = model.CopyAs<UcnhapKho>();
            nhapkho.Id = Guid.NewGuid();
            nhapkho.NgayTao = DateTime.Now;
            nhapkho.IdTrangThai = _context.CmtuDien.Where(x => x.MaTuDien == model.TrangThai).FirstOrDefault().Id;
            _context.UcnhapKho.Add(nhapkho);
            foreach (var item in model.DSChitiet)
            {
                UcchiTietNhapKho ct = new UcchiTietNhapKho();
                ct = item.CopyAs<UcchiTietNhapKho>();
                ct.Id = Guid.NewGuid();
                ct.IdNhapKho = nhapkho.Id;
                _context.UcchiTietNhapKho.Add(ct);
            }
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(UCNhapKhoModel model)
        {
            if (model.DSChitiet.Count() == 0)
            {
                return BadRequest();
            }

            var data = _context.UcnhapKho.Find(model.Id);
            data.Ten = model.Ten;
            data.SoHd = model.SoHd;
            data.GhiChu = model.GhiChu;
            data.TongTien = model.TongTien;
            data.IdTrangThai = _context.CmtuDien.Where(x => x.MaTuDien == model.TrangThai).FirstOrDefault().Id;
            _context.UcnhapKho.Add(data);
            foreach (var item in model.DSChitiet)
            {
                var ct = _context.UcchiTietNhapKho.Find(item.Id);
                ct.Gia = item.Gia;
                ct.SoLuong = item.SoLuong;
                _context.UcchiTietNhapKho.Add(ct);
            }
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteChiTiet(Guid Id)
        {
            var data = _context.UcchiTietNhapKho.Find(Id);
            _context.UcchiTietNhapKho.Remove(data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
