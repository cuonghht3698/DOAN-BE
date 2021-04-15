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

        [HttpGet]
        public ListView<UCNhapKhoModel> getPage(SearchModel model)
        {
            ListView<UCNhapKhoModel> results = new ListView<UCNhapKhoModel>();
            var data = _context.UcnhapKho.ToList();
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
            results.List = data.Select(x => x.CopyAs<UCNhapKhoModel>());
            return results;
        }


        [HttpGet]
        [Route("chitiet")]
        public IEnumerable<UCChiTietNhapKhoModel> getByIdNhapKho (Guid IdNhapKho)
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

            foreach (var item in model.DSChitiet)
            {

            }
        }
    }
}
