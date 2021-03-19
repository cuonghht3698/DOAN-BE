using Device_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class CartDetailModel
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string CartId { get; set; }
        public OptionSanPham Option { get; set; }
        public string Ram
        {
            get
            {
                return Option.Ram;
             }
        }
        public string Rom
        {
            get
            {
                return Option.Rom;
            }
        }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string Mau { get; set; }



    }
}
