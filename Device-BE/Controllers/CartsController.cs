using Device_BE.DTO;
using Device_BE.Models;
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
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public CartsController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("CheckCart/{UserId}")]
        public IEnumerable<Dmcart> CheckCart(Guid UserId)
        {
            Guid TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == "DangGiaoDich").FirstOrDefault().Id;

            var data = _context.Dmcart.Where(x => x.UserId == UserId && x.TrangThaiId == TrangThaiId);
            return data;
        }

        [HttpGet]
        [Route("ShowShoppingCart/{UserId}")]
        public IEnumerable<Dmcart> ShowShoppingCart(Guid UserId, string TrangThai)
        {
            Guid TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == TrangThai).FirstOrDefault().Id;
            var data = _context.Dmcart.Include(x => x.DmcartDetail).Where(x => x.UserId == UserId && x.TrangThaiId == TrangThaiId);
            return data;
        }
        [HttpGet]
        [Route("GetCartByUserId/{Id}")]
        public IEnumerable<Dmcart> GetCartByUserId(Guid Id)
        {
            var data = _context.Dmcart.Find(Id);
            yield return data;
        }
        [HttpPost]
        [Route("CreateNewCart")]
        public IEnumerable<Dmcart> CreateNewCart(CartModel cart)
        {
            cart.Id = Guid.NewGuid();
            
            var data = cart.CopyAs<Dmcart>();
            data.LoaiGiaoDichId = _context.CmtuDien.Where(x => x.MaTuDien == cart.LoaiGiaoDich).FirstOrDefault().Id;
            data.TrangThaiId = _context.CmtuDien.Where(x => x.MaTuDien == cart.TrangThai).FirstOrDefault().Id;
            _context.Dmcart.Add(data);
            _context.SaveChanges();
            yield return data;
        }
    }
}
