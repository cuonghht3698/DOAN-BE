using Device_BE.Database;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;

namespace Device_BE.Controllers
{
    [Route("api/rolemenu")]
    [ApiController]
    public class RoleMenuController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public RoleMenuController(QLPhoneContext context)
        {
            _context = context;
        }

        //[HttpGet("{id}")]
        //[Route("getMenu")]
        //public IEnumerable GetMenu(Guid id)
        //{
        //    var data = _context.HtuserRole.Where(x => x.UserId == id).ToList();
        //    return data;
        //}
        [HttpGet]
        [Route("getRoleUpdate/{id}")]
        public IEnumerable getRoleUpdate(Guid id)
        {
            var data = _context.HtroleMenu.Where(x => x.RoleId == id).Include(x => x.Menu).ToList();
            return data;
        }

        [HttpGet("{id}")]
        public IEnumerable<MenuModel> getRoleMenu(Guid id)
        {
            var data = _context.HtroleMenu.Include(x => x.Menu).Where(x => x.Menu.IsParent == true).ToList();
            var dataCon = _context.HtroleMenu.Where(x => x.RoleId == id).Include(x => x.Menu).Where(x => x.Menu.IsParent == false).ToList();

            List<MenuCon> con = new List<MenuCon>();
            con = dataCon.Select(x => new MenuCon
            {
                Id = x.Id,
                label = x.Menu.Ten,
                faIcon = x.Menu.Icon,
                link = x.Menu.Controller + "/" + x.Menu.Link,
                IdParent = x.Menu.IdParent
            }).ToList();
            
            IEnumerable<MenuModel> models;
            models = data.Select(x => new MenuModel
            {
                Id = x.Id,
                label = x.Menu.Ten,
                Controller = x.Menu.Controller,
                faIcon = x.Menu.Icon,
                IsParent = x.Menu.IsParent.Value,
                link = x.Menu.Link,
                items = con.Where(y => y.IdParent == x.Menu.Id).ToList()
            });

            return models;
        }
        [HttpPost]
        public ActionResult Post(HtroleMenu model)
        {
            model.Id = Guid.NewGuid();
            var data = _context.HtroleMenu.Where(x => x.RoleId.Equals(model.RoleId)).Where(x => x.MenuId.Equals(model.MenuId)).ToList();
            if (data.Count == 0)
            {
                _context.HtroleMenu.Add(model);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();


        }
        [HttpPut]
        public ActionResult Update(HtroleMenu model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Update(Guid id)
        {
            var d = _context.HtroleMenu.Find(id);
            _context.HtroleMenu.Remove(d);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
