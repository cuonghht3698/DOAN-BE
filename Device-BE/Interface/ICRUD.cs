using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Interface
{
    public interface ICRUD<T>
    {

        void Create(T data);
        void Delete(T data);
        void Update(T data);


    }
}
