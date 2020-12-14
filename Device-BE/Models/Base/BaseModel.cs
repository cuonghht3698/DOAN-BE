using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Models.Base
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; set; }
    }
}
