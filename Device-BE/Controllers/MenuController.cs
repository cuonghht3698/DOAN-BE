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
        [Route("getAll")]
        public IEnumerable getAll()
        {
            var data = _context.Htmenu.ToList();
            return data;
        }

        [HttpPost]
        [Route("getPage")]
        public ListSelect getPage(SearchModel search)
        {
            var data =  _context.Htmenu.ToList();
            if(search.sSearch != "")
            {
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch.ToLower())).ToList();
            }
            ListSelect list = new ListSelect();
            list.total = data.Count;
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            list.List = data;
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
        public ActionResult Update(Htmenu model) {
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
