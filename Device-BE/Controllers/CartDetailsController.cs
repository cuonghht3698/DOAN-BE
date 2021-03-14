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
    [Route("api/cartdetail")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public CartDetailsController(QLPhoneContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        [Route("GetCartDetailById/{Id}")]
        public IEnumerable<DmcartDetail> GetCartDetailByUserId(Guid Id)
        {
            var data = _context.DmcartDetail.Find(Id);
            yield return data;
        }


        [HttpPost]
        [Route("CreateNewCartDetail")]
        public ActionResult CreateNewCartDetail(DmcartDetail cart)
        {
            cart.Id = Guid.NewGuid();
            var data = cart.CopyAs<DmcartDetail>();
            _context.DmcartDetail.Add(data);
            _context.SaveChanges();
             return NoContent();
        }
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(Guid Id)
        {
            var data = _context.DmcartDetail.Find(Id);
            _context.DmcartDetail.Remove(data);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
