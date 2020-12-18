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
            var data = await _context.CmtuDien.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex - 1) * search.pageSize).Take(search.pageSize).ToList();
            var query = from td in data
                        join ltd in _context.CmloaiTuDien on td.LoaiTuDienId equals ltd.Id
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
                Active = x.td.Active.Value,
                UuTien = x.td.UuTien.Value,
                LoaiTuDien = x.ltd.Ten,
                LoaiTuDienId = x.ltd.Id
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
                data = data.Where(x=> x.LoaiTuDien.MaLoai.Equals(MaTuDien)).ToList();

            }

            return Ok(data);
        }


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
