using Device_BE.Models;
using Device_BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/tudien")]
    [ApiController]
    public class DMTuDienController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public DMTuDienController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.CmtuDien.Include(x => x.LoaiTuDien).ToListAsync();

            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch)).ToList();
            }
            if (search.LoaiTuDienId != null)
            {
                data = data.Where(x => x.LoaiTuDienId == search.LoaiTuDienId).ToList();
            }
            listData.total = data.Count();
            data = data.Skip((search.pageIndex - 1) * search.pageSize).Take(search.pageSize).OrderBy(x => x.LoaiTuDienId).ToList();
            listData.List = data.Select(x => new TuDienModel
            {
                Id = x.Id,
                TenNgan = x.TenNgan,
                Ten = x.Ten,
                MaTuDien = x.MaTuDien,
                GhiChu = x.GhiChu,
                Active = x.Active.Value,
                UuTien = x.UuTien.Value,
                LoaiTuDien = x.LoaiTuDien.Ten,
                LoaiTuDienId = x.LoaiTuDien.Id
            });
            return Ok(listData);
        }

        [HttpGet]
        [Route("getByLoai")]
        public ActionResult getAllByIdLoai(string MaTuDien)
        {
            var data = _context.CmtuDien.Include(x => x.LoaiTuDien).ToList();
            if (!String.IsNullOrEmpty(MaTuDien))
            {
                data = data.Where(x => x.LoaiTuDien.MaLoai == MaTuDien).ToList();

            }

            return Ok(data.OrderByDescending(x => x.UuTien).ThenBy(x => x.MaTuDien));
        }
        //[HttpGet]
        //[Route("getByLoaiCoSp")]
        //public ActionResult getByLoaiCoSp()
        //{

        //}

        [HttpPost]
        public ActionResult Create(CmtuDien model)
        {
            model.Id = Guid.NewGuid();
            _context.CmtuDien.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(CmtuDien model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.CmtuDien.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.CmtuDien.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
