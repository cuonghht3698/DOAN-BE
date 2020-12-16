using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class HTUserController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public HTUserController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<MyProfileModel> getProfile(Guid Id)
        {
            var user = _context.Htuser.Find(Id);
            return Ok(new MyProfileModel { 
                Id = user.Id,
                DiaChi = user.DiaChi,
                Email = user.Email,
                HoTen = user.HoTen,
                Sdt = user.SoDienThoai,
                TenKhongDau = user.TenKhongDau,
                Tuoi = (int)user.Tuoi,
                Username = user.Username,
                GioiThieu = user.GioiThieu
                
            });
        }
    }
}
