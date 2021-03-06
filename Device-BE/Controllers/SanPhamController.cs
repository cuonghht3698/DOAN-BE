﻿using Device_BE.Database;
using Device_BE.DTO;
using Device_BE.Function;
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
    [Route("api/sanphams")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public SanPhamController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult getAll()
        {
            var data = _context.DmsanPham.ToList();
            return Ok(data);

        }
        //TÌM KIẾM SẢN PHẨM NHẬP HÀNG
        [HttpGet]
        [Route("FindNH")]
        public ActionResult getSP()
        {
            var data = _context.DmsanPham.Take(10).ToList();
            return Ok(data);
        }

        [HttpPost]
        [Route("getPage")]
        public async Task<ActionResult<ListSelect>> getPage(SearchModel search)
        {
            ListSelect listData = new ListSelect();
            var data = await _context.DmsanPham.Include(ch => ch.CauHinh).ToListAsync();
            if (search.sSearch.IsNotNullOrEmpty())
            {
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch.ToLower())).ToList();
            }
            if (search.IdLoaiSanPham != null)
            {
                data = data.Where(x => x.LoaiSpid == search.IdLoaiSanPham).ToList();
            }
            if (search.IdHangSanXuat != null)
            {
                data = data.Where(x => x.HangSxid == search.IdHangSanXuat).ToList();
            }
            if (search.GiaTu != 0)
            {
                data = data.Where(x => x.GiaMacDinh >= search.GiaTu).ToList();

            }
            if (search.GiaDen != 0)
            {
                data = data.Where(x => x.GiaMacDinh <= search.GiaDen).ToList();

            }
            if (search.Active.IsNotNullOrEmpty() && search.Active != "2")
            {
                if (search.Active == "1")
                {
                    data = data.Where(x => x.Active == true).ToList();
                }
                else
                {
                    data = data.Where(x => x.Active == false).ToList();

                }

            }
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            listData.List = data;
            return Ok(listData);
        }


        [HttpPost]
        [Route("showPageDanhMuc")]
        public async Task<ActionResult<ListSelect>> showPageDanhMuc(SearchModel search)
        {
            if (search.GiaTu == null)
            {
                search.GiaTu = 0;
            }
            if (search.GiaDen == null)
            {
                search.GiaDen = 0;
            }
            ListSelect listData = new ListSelect();
            var data = await _context.DmsanPham.Include(x => x.LoaiSp).Include(x => x.CauHinh).Include(x => x.HangSx).ToListAsync();
            if (!String.IsNullOrEmpty(search.sSearch))
            {
                data = data.Where(x => x.Ten.ToLower().Contains(search.sSearch.ToLower()) || x.HangSx.Ten.ToLower().Contains(search.sSearch.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(search.LoaiSP))
            {
                data = data.Where(x => x.LoaiSp.MaTuDien.Equals(search.LoaiSP)).ToList();
            }
            if (!String.IsNullOrEmpty(search.HangSX))
            {
                data = data.Where(x => x.HangSx.MaTuDien.Equals(search.HangSX)).ToList();
            }
            if (search.GiaTu != 0 && search.GiaDen != 0)
            {
                data = data.Where(x => x.GiaMacDinh >= search.GiaTu && x.GiaMacDinh <= search.GiaDen).ToList();
            }
            if (!String.IsNullOrEmpty(search.Ram))
            {
                data = data.Where(x => x.CauHinh.Ram.Contains(search.Ram)).ToList();
            }
            if (!String.IsNullOrEmpty(search.DungLuong))
            {
                data = data.Where(x => x.CauHinh.Dungluong.Contains(search.DungLuong)).ToList();
            }
            listData.total = data.Count();
            data = data.Skip((search.pageIndex) * search.pageSize).Take(search.pageSize).ToList();
            listData.List = data.Select(x => new
            {
                x.Id,
                x.Ten,
                x.GiaMacDinh,
                x.ImageUrl,
                x.MoTa,
                x.Rate,
                x.ViewCount,
                x.KhuyenMai,
                Ram = x.CauHinh != null ? x.CauHinh.Ram : "",
                ManHinh = x.CauHinh != null ? x.CauHinh.ManHinh : "",
                Dungluong = x.CauHinh != null ? x.CauHinh.Dungluong : "",
                Cpu = x.CauHinh != null ? x.CauHinh.Cpu : ""
            });
            return Ok(listData);
        }

        [HttpGet]
        [Route("FindByLoai")]
        public ActionResult FindByLoaiCauHinh(Guid Id)
        {
            var data = _context.DmcauHinh.Where(x => x.LoaiCauHinhId == Id).ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetByLoaiMa/{ma}")]
        public ActionResult GetByLoaiMa(string ma)
        {
            // var tudien =  _context.CmtuDien.Where(x => x.MaTuDien.Equals(ma)).ToList();

            var data = _context.OptionSanPham.Where(x => x.SanPham.LoaiSp.MaTuDien == ma).ToList();

            return Ok(data);
        }
        [HttpGet]
        [Route("getByName")]
        public ActionResult GetNhapHangSP(string search, Guid? IdLoai,Guid? IdHang)
        {
            var data = _context.DmsanPham.Include(x => x.CauHinh).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.Ten.Contains(search)).ToList();
            }
            if (IdLoai != null)
            {
                data = data.Where(x => x.LoaiSpid == IdLoai).ToList();
            }
            if (IdHang != null)
            {
                data = data.Where(x => x.HangSxid == IdHang).ToList();
            }
            var list = data.Select(x => new SanPhamDTO
            {
                Id = x.Id,
                Ten = x.Ten,
                Ram = x.CauHinh != null ? x.CauHinh.Ram : "",
                ManHinh = x.CauHinh != null ? x.CauHinh.ManHinh : "",
                Rom = x.CauHinh != null ? x.CauHinh.Dungluong : "",
                Cpu = x.CauHinh != null ? x.CauHinh.Cpu : "",
                Pin = x.CauHinh != null ? x.CauHinh.Pin : "",
                MoTa = x.MoTa,
                ImageUrl = x.ImageUrl,
                Gia = x.GiaMacDinh

            });
            return Ok(list);
        }
        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult GetNhapHangSPById(Guid id)
        {
            var data = _context.DmsanPham.Where(x => x.Id == id).Include(x => x.CauHinh).ToList();
            var list = data.Select(x => new SanPhamDTO
            {
                Id = x.Id,
                Ten = x.Ten,
                Ram = x.CauHinh != null ? x.CauHinh.Ram : "",
                ManHinh = x.CauHinh != null ? x.CauHinh.ManHinh : "",
                Rom = x.CauHinh != null ? x.CauHinh.Dungluong : "",
                Cpu = x.CauHinh != null ? x.CauHinh.Cpu : "",
                Pin = x.CauHinh != null ? x.CauHinh.Pin : "",
                MoTa = x.MoTa,
                ImageUrl = x.ImageUrl

            });
            return Ok(list);
        }
        [HttpGet]
        [Route("getOptionById/{Id}")]
        public ActionResult getOptionById(Guid Id)
        {
            var data = _context.OptionSanPham.Where(x => x.SanPhamId == Id).Include(x => x.ColorSanPham).ToList();
            return Ok(data);

        }

        [HttpGet]
        [Route("GetNhomMauOptionById/{Id}")]
        public ActionResult GetNhomMauOptionById(Guid Id)
        {
            var data = _context.ColorSanPham.Where(x => x.OptionSanPhamId == Id).ToList();
            return Ok(data);

        }
        [HttpPost]
        public ActionResult Create(DmsanPham model)
        {
            model.Id = Guid.NewGuid();
            var sanpham = model.CopyAs<DmsanPham>();
            _context.DmsanPham.Add(sanpham);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public ActionResult Update(DmsanPham model)
        {
            //var data = _context.DmsanPham.Find(model.Id);
            //if (String.IsNullOrEmpty(data.ImageUrl))
            //{
            //    //data.ImageUrl = model.ImageUrl;
            //}
            //else
            //{
            //    data.ImageUrl = model.ImageUrl;
            //}
            var update = model.CopyAs<DmsanPham>();
            _context.Entry(update).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.DmsanPham.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.DmsanPham.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [Route("getthongso")]
        [HttpPost]
        public ListSelect getthongso(SearchModel model)
        {
            ListSelect list = new ListSelect();
            var data = _context.DmsanPham.Include(x => x.LoaiSp).ToList(); ;
            if (!String.IsNullOrEmpty(model.sSearch))
            {
                data = data.Where(x => x.Ten.ToLower().Contains(model.sSearch.ToLower())).ToList();
            }
            if (model.IdLoaiSanPham != null)
            {
                data = data.Where(x => x.LoaiSpid == model.IdLoaiSanPham).ToList();
            }
            list.total = data.Count;
            data = data.OrderBy(x => x.ThoiGianTao).Skip(model.pageIndex * model.pageSize).Take(model.pageSize).ToList();
            list.List = data.Select(x => new
            {
                Id = x.Id,
                Ten = x.Ten,
                ThongSoKyThuat = x.ThongSoKyThuat,
                LoaiSP = x.LoaiSp.Ten
            });
            return list;
        }

        [Route("updatethongso")]
        [HttpGet]
        public async Task<ActionResult> UpdateThongSo(Guid id, string ThongSoKyThuat)
        {
            var data = await _context.DmsanPham.FindAsync(id);
            data.ThongSoKyThuat = ThongSoKyThuat;
            _context.DmsanPham.Update(data);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [Route("updateView")]
        [HttpGet]
        public ActionResult updateView(Guid Id)
        {
            var data = _context.DmsanPham.Find(Id);
            data.ViewCount += 1;
            _context.DmsanPham.Update(data);
            _context.SaveChanges();
            return NoContent();

        }
        [Route("GetNhapByTenLoaiHang")]
        [HttpGet]
        public ActionResult GetNhap(string Ten, Guid LoaiSpid, Guid HangSxid)
        {
            var data = _context.DmsanPham.ToList();
            if (Ten.IsNotNullOrEmpty())
            {
                data = data.Where(x => x.Ten.ToLower().Contains(Ten.ToLower())).ToList();
            }
            if (LoaiSpid != null)
            {
                data = data.Where(x => x.LoaiSpid == LoaiSpid).ToList();
            }
            if (HangSxid != null)
            {
                data = data.Where(x => x.HangSxid == HangSxid).ToList();
            }
            data = data.Take(10).ToList();
            return Ok(data);

        }
    }
}
