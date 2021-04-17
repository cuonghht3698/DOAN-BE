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
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public RoleController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _context.Htrole.Select(x => new
            {
                x.Ten,
                x.Code
            }).ToList();

            return Ok(data);
        }

        [HttpPost]
        [Route("getPage")]
        public IEnumerable getPage(SearchModel search)
        {
            var data = _context.Htrole.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            if (search.sSearch != "")
            {
                data = data.Where(x => x.Ten.Contains(search.sSearch)).ToList();
            }
            return data;
        }
        [HttpPost]
        public ActionResult Post(Htrole model)
        {
            model.Id = Guid.NewGuid();
            _context.Htrole.Add(model);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Update(Htrole model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult Update(Guid id)
        {
            var d = _context.Htrole.Find(id);
            _context.Htrole.Remove(d);
            _context.SaveChanges();
            return NoContent();

        }


    }
}
