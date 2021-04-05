using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Database
{
    public class MenuModel
    {
        public Guid Id { get; set; }

        public string label { get; set; }
        public string Controller { get; set; }
        public string link { get; set; }
        public string faIcon { get; set; }
        public bool IsParent { get; set; }
        public int UuTien { get; set; }

        public Guid MenuId { get; internal set; }
        public List<MenuCon> items { get; set; }
    }
    public class MenuCon
    {
        public Guid Id { get; set; }
        public string label { get; set; }
        public string Controller { get; set; }
        public string link { get; set; }
        public string faIcon { get; set; }
        public int UuTien { get; set; }
        public Guid? IdParent { get; internal set; }
        public Guid MenuId { get; internal set; }

    }
}
