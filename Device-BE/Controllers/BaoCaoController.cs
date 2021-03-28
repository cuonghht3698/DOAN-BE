using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        
    }
}
