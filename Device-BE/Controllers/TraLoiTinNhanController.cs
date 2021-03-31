using Device_BE.Database;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;

namespace Device_BE.Controllers
{
    [Route("api/tralois")]
    [ApiController]
    public class TraLoiTinNhanController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public TraLoiTinNhanController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet("{Id}")]
        public IEnumerable<TraLoiTinNhanModel> Get(Guid Id)
        {
            var data = _context.HstraLoiTinNhan.Where(x => x.IdTinNhan == Id).OrderBy(x => x.ThoiGianTao).ToList();
            var s = data.Select(x => new TraLoiTinNhanModel
            {

                Id = x.Id,
                Active = x.Active,
                IdTinNhan = x.IdTinNhan,
                NoiDung = x.NoiDung,
                ThoiGianTao = x.ThoiGianTao,
                Watched = x.Watched
            });
            return s;
        }
        [HttpPost]
        public ActionResult PostTinNhan(TraLoiTinNhanModel model)
        {
            model.Id = Guid.NewGuid();
            model.ThoiGianTao = DateTime.Now;
            var tt = model.CopyAs<HstraLoiTinNhan>();
            
            _context.HstraLoiTinNhan.Add(tt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
