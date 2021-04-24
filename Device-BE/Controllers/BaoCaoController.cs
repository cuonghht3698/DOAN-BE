using Device_BE.DTO;
using Device_BE.Management;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/baocaos")]
    [ApiController]
    public class BaoCaoController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public BaoCaoController(QLPhoneContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("BaoCaoTheoThang")]
        public IEnumerable<BaoCaoTongHopModel> BaoCaoTheoThang(Dictionary<string, object> param)
        {
            IEnumerable<BaoCaoTongHopModel> view;
            CallProcedure<BaoCaoTongHopModel> call = new CallProcedure<BaoCaoTongHopModel>(_context);
            view = call.BaoCao("bao_cao_doanh_thu_theo_nam", param);
            return view;
        }

        [HttpPost]
        [Route("TongHopTrangThaiDonHang")]
        public IEnumerable<TongHopTrangThaiDonHangDAO> TongHopTrangThaiDonHang(Dictionary<string, object> param)
        {
            IEnumerable<TongHopTrangThaiDonHangDAO> view;
            CallProcedure<TongHopTrangThaiDonHangDAO> call = new CallProcedure<TongHopTrangThaiDonHangDAO>(_context);
            view = call.BaoCao("tong_hop_trang_thai_don_hang", param);
            return view;
        }

        [HttpPost]
        [Route("Baocaotheonhanvien")]
        public IEnumerable<BaoCaoNhanVienDTO> bao_cao_theo_nhan_vien(Dictionary<string, object> param)
        {
            IEnumerable<BaoCaoNhanVienDTO> view;
            CallProcedure<BaoCaoNhanVienDTO> call = new CallProcedure<BaoCaoNhanVienDTO>(_context);
            view = call.BaoCao("bao_cao_theo_nhan_vien", param);
            return view;
        }
    }
}
