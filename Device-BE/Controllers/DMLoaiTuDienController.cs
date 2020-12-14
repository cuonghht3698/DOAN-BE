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
    [Route("api/loaitudien")]
    [ApiController]
    public class DMLoaiTuDienController : ControllerBase
    {
        private readonly DeviceContext _context;
        public DMLoaiTuDienController(DeviceContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.CMLoaiTuDiens.ToList();
            return Ok(data);
                   
        }



        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.CMLoaiTuDiens.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from ltt in data
                        select ltt;
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.Ten.ToLower().Contains(search.sSearch) || x.MaLoai.Contains(search.sSearch));
            }

            listData.List = query.Select(x => new LoaiTuDienModel
            {
                Id = x.Id,
                MaLoai = x.MaLoai,
                Ten = x.Ten
            });
            return Ok(listData);
        }


        [HttpPost]
        public ActionResult Create(CMLoaiTuDien model)
        {
            model.Id = new Guid();
            _context.CMLoaiTuDiens.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(CMLoaiTuDien model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.CMLoaiTuDiens.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.CMLoaiTuDiens.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
