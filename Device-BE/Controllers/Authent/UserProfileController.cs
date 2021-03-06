﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Device_BE.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Device_BE.Models.User;

namespace Device_BE.Controllers
{
    [Route("api/userprofile")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly QLPhoneContext _context;


        public UserProfileController(QLPhoneContext context)
        {
            _context = context;

        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //GET : /api/UserProfile
        public ActionResult GetUserProfile()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type.Equals("UserID", StringComparison.InvariantCultureIgnoreCase)).Value;
            var user = _context.Htuser.Where(x =>x.Id == new Guid(userId));
            bool checkChuaDangNhap = false;
            // ussername là tài khoản mặc định khi chưa đăng nhập
            if (user.FirstOrDefault().Username == "khachhang")
            {
                checkChuaDangNhap = true;
            }
            var data = from list in user
                       join r in _context.HtuserRole on list.Id equals r.UserId
                       join r1 in _context.Htrole on r.RoleId equals r1.Id
                       select new InfoUserModel
                       {
                           Id = list.Id,
                           HoTen = list.HoTen,
                           DiaChi = list.DiaChi,
                           Role = r1.Code,
                           RoleId = r1.Id,
                           Sdt = list.SoDienThoai,
                           Email = list.Email,
                           checkChuaDangNhap = checkChuaDangNhap
                       };
            return Ok(data.ToList());
            
        }

    }
}