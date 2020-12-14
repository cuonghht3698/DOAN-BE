using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Device_BE.Models;
using Device_BE.Models.MDevice;
using Device_BE.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly DeviceContext _context;
        private readonly ApplicationSetting _appSettings;
        public ApplicationUserController(DeviceContext context, IOptions<ApplicationSetting> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(UserModel model)
        {
            var used = _context.HTUsers.ToList().Where(x => x.Username == model.Username);

            if (used.Count() > 0)
            {
                return false;
            }
            var password = PasswordHash.EncodePassword(model.Password);

            var applicationUser = new HTUser()
            {
                Username = model.Username,
                PasswordHash = password,
                Email = model.Email,
                HoTen = model.HoTen
            };

            try
            {
                await _context.HTUsers.AddAsync(applicationUser);
                await _context.SaveChangesAsync();
                return used;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public ActionResult Login(LoginModel model)
        {
            var checkPass = PasswordHash.EncodePassword(model.Password);

            var user = _context.HTUsers.Where(x => x.Username == model.UserName && x.PasswordHash == checkPass);


            if (user.Count() > 0)
            {
                var UserId = from list in user
                             select list;

                var Id = UserId.Select(x => x.Id).FirstOrDefault();
                var HoTen = UserId.Select(x => x.HoTen).FirstOrDefault();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",Id.ToString()),
                        new Claim("Name",HoTen.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}