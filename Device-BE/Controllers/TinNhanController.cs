using Device_BE.Database;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Func;

namespace Device_BE.Controllers
{
    [Route("api/tinnhans")]
    [ApiController]
    public class TinNhanController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public TinNhanController(QLPhoneContext context)
        {
            _context = context;
        }
       

        [HttpGet]
        [Route("CreateOrGet/{UserId}")]
        public ActionResult CreateOrGet(Guid UserId)
        {
            var data = _context.HstinNhan.Where(x => x.UserId == UserId).FirstOrDefault();
            if (data == null)
            {
                HstinNhan hs = new HstinNhan();
                hs.Id = Guid.NewGuid();
                hs.ThoiGianTao = DateTime.Now;
                hs.Active = true;
                hs.UserId = UserId;
                _context.HstinNhan.Add(hs);
                _context.SaveChanges();
                return Ok(hs);
            }
            else
            {
                return Ok(data);

            }
        }
    }
}
