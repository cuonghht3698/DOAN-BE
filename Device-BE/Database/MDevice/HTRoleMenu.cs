using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.MDevice
{
    public class HTRoleMenu
    {
        public System.Guid Id { get; set; }
        [ForeignKey("IdRole")]

        public HTRole HTRole { get; set; }
        [ForeignKey("IdMenu")]

        public HTMenu HTMenu  { get; set; }
        public Nullable<int> UuTien { get; set; }
        [StringLength(500)]
        public string Mota { get; set; }

    }
}
