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
    [Route("api/cauhinhs")]
    [ApiController]
    public class CauHinhController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public CauHinhController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.DmcauHinh.ToList();
            return Ok(data);

        }



        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.DmcauHinh.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from ltt in data
                        join cm in _context.CmtuDien on ltt.LoaiCauHinhId equals cm.Id
                        select (ltt, cm);
            //if (!String.IsNullOrEmpty(search.sSearch))
            //{
            //    search.sSearch = search.sSearch.ToLower();
            //    query = query.Where(x => x.Ten.ToLower().Contains(search.sSearch));
            //}

            listData.List = query.Select(x => new DmcauHinh
            {
                Id = x.ltt.Id,
                ManHinh = x.ltt.ManHinh,
                Cpu = x.ltt.Cpu,
                Pin = x.ltt.Pin,
                Mota = x.ltt.Mota,
                Ngaysx = x.ltt.Ngaysx,
                Ram = x.ltt.Ram,
                ThoiGianBaoHanh =x.ltt.ThoiGianBaoHanh,
                Dungluong = x.ltt.Dungluong,
                LoaiCauHinhId = x.ltt.LoaiCauHinhId,
                LoaiCauHinh = x.cm
            });
            return Ok(listData);
        }

        [HttpGet]
        [Route("FindByLoai")]
        public ActionResult FindByLoaiCauHinh(Guid Id)
        {
            var data = _context.DmcauHinh.Where(x =>x.LoaiCauHinhId == Id).ToList();
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Create(DmcauHinh model)
        {
            model.Id = Guid.NewGuid();
            if (String.IsNullOrEmpty(model.Mota))
            {
                model.Mota = "Cpu: " + model.Cpu +"Ram: "+ model.Ram + "Pin: " + model.Pin + "Màn hình: " + model.ManHinh + ".....";
            }
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
