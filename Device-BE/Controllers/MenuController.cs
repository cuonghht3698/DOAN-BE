using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public MenuController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll/{id}")]
        public ActionResult getAll(Guid id)
        {
            //id là id role
            var MenuCuaRole = _context.HtroleMenu.Include(x => x.Menu).Where(x => x.RoleId == id).ToList();



            var list = MenuCuaRole.Select(x => new { 
                Id = x.Id,
                Ten = x.Menu.Ten,
                Icon = x.Menu.Icon,
                IsParent = x.Menu.IdParent,
                Link = x.Menu.Link,
                MoTa = x.Menu.Mota,
                Controller = x.Menu.Controller,
                IdParent = x.Menu.IdParent,
                Cha = x.Menu.IdParent != null? _context.Htmenu.Find(x.Menu.IdParent) : null

            });
            return Ok(list);
        }
        [HttpGet]
        [Route("getThemRole")]
        public ActionResult getThemRole(string search)
        {
            //id là id role
            var MenuCuaRole = _context.Htmenu.OrderBy(x => x.IdParent).ToList();

            if (!String.IsNullOrEmpty(search))
            {
                MenuCuaRole = MenuCuaRole.Where(x => x.Ten.ToLower().Contains(search.ToLower())).ToList();
            }

            var list = MenuCuaRole.Select(x => new {
                Id = x.Id,
                Ten = x.Ten,
                Cha = x.IdParent
            });
            return Ok(list);
        }
        [HttpGet]
        [Route("getParent")]
        public ActionResult getParent()
        {
            var data = _context.Htmenu.Where(x => x.IsParent == true).ToList();
            var list = data.Select(x => new
            {
                x.Id,
                x.Ten
            });
            return Ok(list) ;
        }
        [HttpPost]
        [Route("getPage")]
        public ListSelect getPage(SearchModel search)
        {
            var data = _context.Htmenu.ToList();
            if (search.sSearch != "")
            {
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch.ToLower())).OrderBy(x => x.IdParent).ToList();
            }
           
            ListSelect list = new ListSelect();
            list.total = data.Count;
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            list.List = data.Select(x => new {
                Id = x.Id,
                Ten = x.Ten,
                Icon = x.Icon,
                IsParent = x.IsParent,
                Link = x.Link,
                MoTa = x.Mota,
                Controller = x.Controller,
                IdParent = x.IdParent,
                Cha = x.IdParent != null ? _context.Htmenu.Find(x.IdParent).Ten : null

            }).OrderBy(x => x.IdParent);
            return list;
        }
        [HttpPost]
        public ActionResult Post(Htmenu model)
        {
            model.Id = Guid.NewGuid();
            _context.Htmenu.Add(model);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Update(Htmenu model)
        {
            if (model.IsParent == true)
            {
                model.IdParent = null;
            }
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult Update(Guid id)
        {
            var d = _context.Htmenu.Find(id);
            _context.Htmenu.Remove(d);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
