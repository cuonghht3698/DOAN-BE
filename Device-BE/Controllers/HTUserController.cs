using Device_BE.Models;
using Device_BE.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Func;

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

        [HttpPost]
        [Route("getPage")]

        public async Task<ActionResult> ShowPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.Htuser.ToListAsync();
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            var query = from td in data
                        join ur in _context.HtuserRole on td.Id equals ur.UserId
                        join rl in _context.Htrole on ur.RoleId equals rl.Id
                         select (td,rl);
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                search.sSearch = search.sSearch.ToLower();
                query = query.Where(x => x.td.HoTen.ToLower().Contains(search.sSearch)).ToList();
            }
            listData.List = query.Select(x => new MyProfileModel
            {
                Id = x.td.Id,
                DiaChi = x.td.DiaChi,
                Email = x.td.Email,
                HoTen = x.td.HoTen,
                Sdt = x.td.SoDienThoai,
                TenKhongDau = x.td.TenKhongDau,
                NgaySinh = x.td.NgaySinh.GetValueOrDefault(),
                Username = x.td.Username,
                GioiThieu = x.td.GioiThieu,
                Role = x.rl.Ten
            }).ToList();
            return Ok(listData);
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
                NgaySinh = (DateTime)user.NgaySinh,
                Username = user.Username,
                GioiThieu = user.GioiThieu
            });
        }

        [HttpPost]
        [Route("changepass")]
        public ActionResult ChangePassword(PasswordModel model)
        {
            var user = _context.Htuser.Find(model.Id);
            var passOld = PasswordHash.EncodePassword(model.PasswordOld);
            var passNew = PasswordHash.EncodePassword(model.PasswordNew);
            if (passOld == user.PasswordHash)
            {
                if(model.PasswordNew == model.PasswordConfirm)
                {
                    user.PasswordHash = passNew;
                    _context.Htuser.Update(user);
                    _context.SaveChanges();
                }
                else
                {
                    return BadRequest();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("changeprofile")]
        public ActionResult ChangeProfile([FromBody] MyProfileModel model)
        {
            var user = _context.Htuser.Find(model.Id);
            var dataChange = model.CopyAs<Htuser>();
            _context.Entry(dataChange).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        [Route("updateUser")]
        public ActionResult updateUser(MyProfileModel model)
        {
            var user = _context.Htuser.Find(model.Id);
            user.HoTen = model.HoTen;
            user.SoDienThoai = model.Sdt;
            user.TenKhongDau = model.TenKhongDau;
            user.NgaySinh = model.NgaySinh;
            user.GioiThieu = model.GioiThieu;
            user.Email = model.Email;
            user.DiaChi = model.DiaChi;
            user.Username = model.Username;

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (Guid id)
        {
            var role = _context.HtuserRole.Where(x =>x.UserId == id).ToList();
            _context.HtuserRole.Remove(role);

            _context.Htuser.Remove(_context.Htuser.Find(id));
            _context.SaveChanges();
            return NoContent();
        }

    }
}
