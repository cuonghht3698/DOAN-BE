using Device_BE.Models;
using Device_BE.Models.MDevice;
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
        private readonly DeviceContext _context;
        public DMTuDienController(DeviceContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.CMTuDiens.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from td in data
                        join ltd in _context.CMLoaiTuDiens on td.LoaiTuDienId equals ltd.Id
                        select (td,ltd);
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.td.Ten.ToLower().Contains(search.sSearch));
            }
            if (search.LoaiTuDienId != Guid.Empty)
            {
                query = query.Where(x => x.td.LoaiTuDienId == search.LoaiTuDienId);
            }
            listData.List = query.Select(x => new TuDienModel
            {
                Id = x.td.Id,
                TenNgan = x.td.TenNgan,
                Ten = x.td.Ten,
                MaTuDien = x.td.MaTuDien,
                GhiChu = x.td.GhiChu,
                Active = x.td.Active,
                UuTien = x.td.UuTien,
                LoaiTuDien = x.ltd.Ten,
                LoaiTuDienId = x.ltd.Id
            });
            return Ok(listData);
        }


        [HttpPost]
        public ActionResult Create(CMTuDien model)
        {
            model.Id = new Guid();
            _context.CMTuDiens.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(CMTuDien model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.CMTuDiens.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.CMTuDiens.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
