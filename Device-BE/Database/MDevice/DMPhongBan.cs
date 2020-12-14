using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Device_BE.Models.MDevice
{
    public class DMPhongBan
    {
        public System.Guid Id { get; set; }
        public string Ten { get; set; }
        [ForeignKey("IdChiNhanh")]
        public DMChiNhanh dMChiNhanh { get; set; }
        [ForeignKey("UserId")]
        public HTUser HTUser { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}