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
    [Route("api/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public BlogController(QLPhoneContext context)
        {
            _context = context;
        }

        [Route("getPage")]
        [HttpPost]
        public ListSelect getPage(SearchModel model)
        {
            ListSelect list = new ListSelect();
            var data = _context.Blog.Include(x => x.IdSanPhamNavigation).ToList();
            if (!String.IsNullOrEmpty(model.sSearch))
            {
                data = data.Where(x => x.TieuDe.ToLower().Contains(model.sSearch.ToLower()) ||
                x.IdSanPhamNavigation.Ten.ToLower().Contains(model.sSearch.ToLower())).ToList();
            }
            list.total = data.Count;
            data = data.OrderBy(x => x.ThoiGianTao).Skip(model.pageIndex * model.pageSize).Take(model.pageSize).ToList();
            list.List = data.Select(x => new
            {
                Id = x.Id,
                TieuDe = x.TieuDe,
                TieuDeKhongDau = x.TieuDeKhongDau,
                //NoiDung = x.NoiDung,
                Link = x.Link,
                Active = x.Active,
                ThoiGianTao = x.ThoiGianTao,
                SanPham = x.IdSanPhamNavigation != null ? x.IdSanPhamNavigation.Ten : ""
            }); 
            return list;
        }
        [HttpGet]
        [Route("getById")]
        public Blog getById(Guid Id)
        {

            var data = _context.Blog.Find(Id).CopyAs<Blog>();
            return data;
        }

        [HttpGet]
        [Route("getByIdSanPham")]
        public Blog getByIdSanPham(Guid Id)
        {

            var data = _context.Blog.Where(x => x.IdSanPham == Id).FirstOrDefault().CopyAs<Blog>();
            return data;
        }
        [HttpPost]
        public Blog Post(BlogModel blog)
        {
            blog.Id = Guid.NewGuid();
            blog.ThoiGianTao = DateTime.Now;
            var data = blog.CopyAs<Blog>();
            _context.Blog.Add(data);
            _context.SaveChanges();
            return data;
        }
        [HttpPut]
        public ActionResult Update(BlogModel blog)
        {
            blog.ThoiGianTao = DateTime.Now;
            var data = blog.CopyAs<Blog>();
            _context.Blog.Update(data);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(Guid Id)
        {
            var data = _context.Blog.Find(Id);
            _context.Blog.Remove(data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
