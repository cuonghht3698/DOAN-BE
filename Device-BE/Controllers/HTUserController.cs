using Dapper;
using Device_BE.Models;
using Device_BE.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
                        where (search.RoleId is null || ur.RoleId.Equals(search.RoleId.Value))
                        select (td, rl);
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
                SoDienThoai = x.td.SoDienThoai,
                TenKhongDau = x.td.TenKhongDau,
                NgaySinh = x.td.NgaySinh.GetValueOrDefault(),
                Username = x.td.Username,
                GioiThieu = x.td.GioiThieu,
                Role = x.rl.Ten,
                RoleId = x.rl.Id,
                Code = x.rl.Code,
            }).ToList();
            return Ok(listData);
        }


        [HttpGet("{id}")]
        public ActionResult<MyProfileModel> getProfile(Guid Id)
        {
            var user = _context.Htuser.Find(Id);
            return Ok(new MyProfileModel
            {
                Id = user.Id,
                DiaChi = user.DiaChi,
                Email = user.Email,
                HoTen = user.HoTen,
                SoDienThoai = user.SoDienThoai,
                TenKhongDau = user.TenKhongDau,
                NgaySinh = (DateTime)user.NgaySinh.Value,
                Username = user.Username,
                GioiThieu = user.GioiThieu != null ? user.GioiThieu : ""
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
                if (model.PasswordNew == model.PasswordConfirm)
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
            user.Email = model.Email;
            user.DiaChi = model.DiaChi;
            user.SoDienThoai = model.SoDienThoai;
            user.GioiThieu = model.GioiThieu;
            user.HoTen = model.HoTen;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        [Route("updateUser")]
        public ActionResult updateUser(MyProfileModel model)
        {
            //var user = _context.Htuser.Find(model.Id);
            //user.HoTen = model.HoTen;
            //user.SoDienThoai = model.SoDienThoai;
            //user.TenKhongDau = model.HoTen;
            //user.NgaySinh = model.NgaySinh;
            //user.GioiThieu = model.GioiThieu;
            //user.Email = model.Email;
            //user.DiaChi = model.DiaChi;
            //user.Username = model.Username;
            if (model.Password != "")
            {
                model.Password = PasswordHash.EncodePassword(model.Password);
            }
            var role = _context.Htrole.Where(x => x.Code == model.Role).FirstOrDefault();

            using (var cnn = (_context as DbContext).Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                var p = new DynamicParameters();
                p.Add("UserId", model.Id);
                p.Add("RoleId", role.Id);
                p.Add("HoTen", model.HoTen);
                p.Add("SoDienThoai", model.SoDienThoai);
                p.Add("Email", model.Email);
                p.Add("DiaChi", model.DiaChi);
                p.Add("Password", model.Password);

                cnn.Query("changeRole", p, commandType: CommandType.StoredProcedure);

            }
            //_context.Htuser.Update(user);
            //_context.SaveChanges();
            return NoContent();
        }
    
    [HttpPost]
    [Route("create")]
    public ActionResult Create(UserModel model)
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
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var role = _context.HtuserRole.Where(x => x.UserId == id);
        _context.HtuserRole.Remove(role.FirstOrDefault());

        _context.Htuser.Remove(_context.Htuser.Find(id));
        _context.SaveChanges();
        return Ok(role);
    }

}
}
