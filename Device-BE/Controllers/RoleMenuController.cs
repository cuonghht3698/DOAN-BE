using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpGet("{id}")]
        public IEnumerable getRoleMenu(Guid id)
        {
            var data = _context.HtroleMenu.Where(x =>x.RoleId == id).Include(x =>x.Menu).ToList();
            return data;
        }
        [HttpPost]
        public ActionResult Post(HtroleMenu model)
        {
            model.Id = Guid.NewGuid();
            _context.HtroleMenu.Add(model);
            _context.SaveChanges();
            return NoContent();
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
