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
        [Route("GetDSTinNhanByTen")]
        public IEnumerable<TinNhanModel> GetDSTinNhan(string ten)
        {
            var data = _context.HstinNhan.Include(x => x.User).Include(x => x.HstraLoiTinNhan).ToList();
            if (!String.IsNullOrEmpty(ten))
            {
                data = data.Where(x => x.User.HoTen.Contains(ten)).ToList();
            }
            IEnumerable<TinNhanModel> tinNhans;

            tinNhans = data.Select(x => new TinNhanModel
            {
                Id = x.Id,
                UserId = x.UserId.Value,
                HoTen = x.User.HoTen,
                FirstTinNhan = x.HstraLoiTinNhan.Count >0 ? x.HstraLoiTinNhan.OrderByDescending(y => y.ThoiGianTao).FirstOrDefault().NoiDung : "",
                NgayTao = x.HstraLoiTinNhan.Count > 0 ? x.HstraLoiTinNhan.OrderByDescending(y => y.ThoiGianTao).FirstOrDefault().ThoiGianTao : null,
                Watch = x.HstraLoiTinNhan.Count > 0 ? x.HstraLoiTinNhan.OrderByDescending(y => y.ThoiGianTao).FirstOrDefault().Watched : null,
            });

            return tinNhans.OrderByDescending(x => x.NgayTao);
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
