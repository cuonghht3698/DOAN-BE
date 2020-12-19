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
    [Route("api/nhacungcaps")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public NhaCungCapController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.DmnhaCungCap.ToList();
            return Ok(data);

        }



        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.DmnhaCungCap.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from ltt in data
                        select ltt;
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.Ten.ToLower().Contains(search.sSearch));
            }

            listData.List = query.Select(x => new DmnhaCungCap
            {
                Id = x.Id,
                Active = x.Active,
                DiaChi = x.DiaChi,
                Mota = x.Mota,
                Sdt = x.Sdt,
                Ten = x.Ten,
            });
            return Ok(listData);
        }


        [HttpPost]
        public ActionResult Create(DmnhaCungCap model)
        {
            model.Id = Guid.NewGuid();
            _context.DmnhaCungCap.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(DmnhaCungCap model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.DmnhaCungCap.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.DmnhaCungCap.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
