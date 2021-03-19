using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Device_BE.Interface;
using Device_BE.Models;
using Device_BE.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Func;

namespace WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        private readonly ApplicationSetting _appSettings;
        public ApplicationUserController(QLPhoneContext context, IOptions<ApplicationSetting> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/authentication/Register
        public ActionResult PostApplicationUser(UserModel model)
        {
            var used = _context.Htuser.ToList().Where(x => x.Username == model.Username);

            if (used.Count() > 0)
            {
                return BadRequest();
            }
            var password = PasswordHash.EncodePassword(model.Password);
            model.Id = Guid.NewGuid();
            var applicationUser = model.CopyAs<Htuser>();
            applicationUser.PasswordHash = password;
            try
            {
                 _context.Htuser.Add(applicationUser);


                var role = new HtuserRole
                {

                    UserId = model.Id,
                    RoleId = _context.Htrole.Where(x => x.Code == model.Role).FirstOrDefault().Id
                };
                 _context.HtuserRole.Add(role);
                 _context.SaveChanges();
                return Ok(applicationUser);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public ActionResult Login(LoginModel model)
        {
            var checkPass = PasswordHash.EncodePassword(model.Password);

            var user = _context.Htuser.Where(x => x.Username == model.UserName && x.PasswordHash == checkPass);


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