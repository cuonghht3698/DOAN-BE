using Device_BE.Database;
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
        [Route("GetPage")]
        public ActionResult GetPage(ModelSearchSP model)
        {
            var data = _context.DmsanPham.Include(x => x.OptionSanPham).ToList();
            if (!String.IsNullOrEmpty(model.sSearch))
            {
                data = data.Where(x => x.Ten.Contains(model.sSearch)).ToList();
            }
            data = data.Skip((model.pageIndex -1) * model.pageSize).Take(model.pageSize).ToList();
            data = model.OrderByAsc ? data.OrderBy(x => x.ViewCount).ToList() : data.OrderByDescending(x => x.ViewCount).ToList();
            var result = data.Select(x => new 
            {
                x.Id,
                x.Ten,
                x.MoTa,
                x.Rate,
                x.GiaMacDinh,
                x.ViewCount,
                x.ImageUrl,
                ListOption = x.OptionSanPham.Select(y => new { 
                    y.Id,
                    y.Ram,
                    y.Rom,
                    y.Gia,
                    y.SoLuong
                    
                })
            });

            return Ok(result);
            
        }


        [HttpGet]
        [Route("GetOptionByHang/{MaHang}")]
        public ActionResult GetOptionByHang(string MaHang)
        {
            ListSelect listData = new ListSelect();
            var data = _context.OptionSanPham.ToList();
            var query = from o in data
                        join s in _context.DmsanPham on o.SanPhamId equals s.Id
                        join ch in _context.DmcauHinh on s.CauHinhId equals ch.Id
                        join cm in _context.CmtuDien on s.HangSxid equals cm.Id
                        where MaHang == "" || cm.MaTuDien.Equals(MaHang)
                        group o by new
                        {
                            o.SanPhamId,
                            s.ImageUrl,
                            s.Ten,
                            s.Rate,
                            s.GiaMacDinh,
                            s.ViewCount,
                            cm.TenNgan,
                            ch.Dungluong
                        } into gcs
                        select (gcs);
            listData.total = query.Count();
            listData.List = query.Select(x => new ViewSanPhamModel
            {
                Id = x.Key.SanPhamId.Value,
                Ten = x.Key.Ten,
                ImageUrl = x.Key.ImageUrl,
                Rate = x.Key.Rate.Value,
                ViewCount = x.Key.ViewCount.Value,
                Hang = x.Key.TenNgan,
                Gia = x.Key.GiaMacDinh,
                DungLuong = x.Key.Dungluong
            });
            return Ok(listData.List);
        }

        [HttpGet]
        [Route("GetOptionByIdSp/{Id}")]
        public ActionResult GetOptionByIdSp(Guid Id)
        {
            var data = _context.DmsanPham.Include(x => x.OptionSanPham).Include(y => y.LoaiSp).Where(x => x.Id == Id).ToList();

            var list = data.Select(x => new
            {
                x.Id,
                x.Ten,
                x.MoTa,
                Loaisp = x.LoaiSp.Ten,
                x.KhuyenMai,
                x.ImageUrl,
                x.Rate,
                x.GiaMacDinh,
                x.ViewCount,
                x.ThongSoKyThuat,
                Option = x.OptionSanPham.Select(y => new
                {
                    y.Id,
                    y.SanPhamId,
                    y.Ram,
                    y.Rom,
                    y.SoLuong,
                    y.Gia
                })
            });
            return Ok(list);
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

        [HttpPost]
        [Route("TruSoLuong")]
        public ActionResult UpdateSoLuong(List<UpdateSoLuong> model)
        {
            foreach (var item in model)
            {
                var option = _context.OptionSanPham.Find(item.Id);
                option.SoLuong = option.SoLuong - item.SoLuong;
                _context.OptionSanPham.Update(option);
            }
           
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("CongSoLuong")]
        public ActionResult CongSoLuong(List<UpdateSoLuong> model)
        {
            foreach (var item in model)
            {
                var option = _context.OptionSanPham.Find(item.Id);
                option.SoLuong = option.SoLuong + item.SoLuong;
                _context.OptionSanPham.Update(option);
            }

            _context.SaveChanges();
            return NoContent();
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
