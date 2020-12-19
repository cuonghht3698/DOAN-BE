using Device_BE.Database;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;

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
            var data = await _context.DmsanPham.Include(ch => ch.CauHinh).Include(l => l.LoaiSp)
                .Include(x => x.TrangThai).Include(x => x.NhaCungCap).Include(x => x.NguoiNhap).Include(x => x.Kho).ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex -1) * search.pageSize).Take(search.pageSize).ToList();
            listData.List = data;
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
        public ActionResult Create(DmsanPham model)
        {
            model.Id = Guid.NewGuid();
            var sanpham = model.CopyAs<DmsanPham>();
            _context.DmsanPham.Add(sanpham);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(DmsanPham model)
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
