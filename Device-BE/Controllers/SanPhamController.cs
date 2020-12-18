using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/sanphams")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public SanPhamController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.DmsanPham.ToList();
            return Ok(data);

        }



        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.DmsanPham.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from ltt in data
                        join loai in _context.CmtuDien on ltt.LoaiSpid equals loai.Id
                        join cm in _context.CmtuDien on ltt.TrangThaiId equals cm.Id
                        join ncc in _context.DmnhaCungCap on ltt.NhaCungCapId equals ncc.Id
                        join anh in _context.Dmanh on ltt.AnhId equals anh.Id

                        select (ltt, loai, cm , ncc, anh);
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.ltt.Ten.ToLower().Contains(search.sSearch));
            }

            listData.List = query.Select(x => new DmsanPham
            {
                Id = x.ltt.Id,
                TenNgan = x.ltt.TenNgan,
                MoTa = x.ltt.MoTa,
                Rate = x.ltt.Rate,
                ViewCount = x.ltt.ViewCount,
                ThoiGianTao = x.ltt.ThoiGianTao,
                ThoiGianDong = x.ltt.ThoiGianDong,
                SeriesNumber = x.ltt.SeriesNumber,
                Color = x.ltt.Color,
                Gia = x.ltt.Gia,
                TrangThaiId = x.ltt.TrangThaiId,
                TrangThai = x.cm,
                NhaCungCapId = x.ltt.NhaCungCapId,
                NhaCungCap = x.ncc,
                AnhId = x.ltt.AnhId,
                Anh = x.anh,
                NguoiNhapId = x.ltt.NguoiNhapId,
                KhoId = x.ltt.KhoId,
                LoaiSpid = x.ltt.LoaiSpid,
                KhuyenMai = x.ltt.KhuyenMai,
                CauHinhId = x.ltt.CauHinhId

            });
            return Ok(listData);
        }

        [HttpGet]
        [Route("FindByLoai")]
        public ActionResult FindByLoaiCauHinh(Guid Id)
        {
            var data = _context.DmcauHinh.Where(x => x.LoaiCauHinhId == Id).ToList();
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Create(DmcauHinh model)
        {
            model.Id = Guid.NewGuid();
            _context.DmcauHinh.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(DmcauHinh model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.DmcauHinh.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.DmcauHinh.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
