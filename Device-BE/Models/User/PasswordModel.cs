using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.User
{
    public class PasswordModel
    {
        public Guid Id { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
