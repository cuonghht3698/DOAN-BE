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
    [Route("api/tinhthanhs")]
    [ApiController]
    public class DMTinhThanhController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public DMTinhThanhController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.DmtinhThanh.ToList();
            return Ok(data);

        }



        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.DmtinhThanh.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from ltt in data
                        select ltt;
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.Ten.ToLower().Contains(search.sSearch));
            }

            listData.List = query.Select(x => new DmtinhThanh { 
                Id = x.Id,
                Active = x.Active,
                IdLoaiTinhThanh = x.IdLoaiTinhThanh,
                MoTa = x.MoTa,
                ParentId = x.ParentId,
                Ten = x.Ten,
                UuTien = x.UuTien,
                Parent = _context.DmtinhThanh.Find(x.ParentId)
                
            });
            return Ok(listData);
        }


        [HttpPost]
        public ActionResult Create(DmtinhThanh model)
        {
            model.Id = Guid.NewGuid();
            _context.DmtinhThanh.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(DmtinhThanh model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.DmtinhThanh.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.DmtinhThanh.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
