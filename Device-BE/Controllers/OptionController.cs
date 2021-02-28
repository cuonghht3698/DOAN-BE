using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/options")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public OptionController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Insert(OptionSanPham option)
        {
            var data = _context.OptionSanPham.Where(x => x.Ram.Equals(option.Ram)).Where(x => x.Rom.Equals(option.Rom)).Where(x => x.SanPhamId.Equals(option.SanPhamId)).ToList();
            if (data.Count > 0)
            {
                return BadRequest();
            }
            option.Id = Guid.NewGuid();
            _context.OptionSanPham.Add(option);
            _context.SaveChanges();
            return Ok(option);
        }

        [HttpPut]
        public ActionResult Update(OptionSanPham option)
        {
            var data = _context.OptionSanPham.Where(x => x.Ram.Equals(option.Ram)).Where(x => x.Rom.Equals(option.Rom)).Where(x => x.SanPhamId.Equals(option.SanPhamId)).ToList();
            if (data.Count > 0)
            {
                if (data[0].Id == option.Id)
                {
                    data[0].Ram = option.Ram;
                    data[0].Rom = option.Rom;
                    data[0].SoLuong = option.SoLuong;
                    data[0].Gia = option.Gia;
                    _context.OptionSanPham.Update(data[0]);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return BadRequest();

                }
            }
            else
            {
                _context.OptionSanPham.Update(option);
                _context.SaveChanges();
                return NoContent();
            }

            
        }
    }
}
