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
    [Route("api/khos")]
    [ApiController]
    public class KhosController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public KhosController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.Dmkho.ToListAsync();

            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch)).ToList();
            }
           
            listData.total = data.Count();
            data = data.Skip((search.pageIndex - 1) * search.pageSize).Take(search.pageSize).ToList();
            listData.List = data.Select(x => new 
            {
                Id = x.Id,
                Ten = x.Ten,
                Active = x.Active
            });
            return Ok(listData);
        }

     
        [HttpPost]
        public ActionResult Create(Dmkho model)
        {
            model.Id = Guid.NewGuid();
            _context.Dmkho.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(Dmkho model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.Dmkho.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.Dmkho.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
