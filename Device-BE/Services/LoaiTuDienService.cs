using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Services
{
    public class LoaiTuDienService
    {
        private static LoaiTuDienService _instance;
        private LoaiTuDienService() { }
        public static LoaiTuDienService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoaiTuDienService();
                }
                return _instance;
            }
        }

        private readonly QLPhoneContext _context;
        public LoaiTuDienService(QLPhoneContext context)
        {
            _context = context;
        }
        public IEnumerable<LoaiTuDienModel> getPage()
        {
           var data = _context.CmloaiTuDien.ToList();
           return data.Select(x => new LoaiTuDienModel
            {
                Id = x.Id,
                MaLoai = x.MaLoai,
                Ten = x.Ten
            });
        }

    }
}
