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

        //[HttpGet]
        //public List<CallProc> BaoCao(Dictionary<string, object> param)
        //{
        //    CallProcedure<CallProc> call = new CallProcedure<CallProc>(_context);
        //    var data = call.BaoCao("bao_cao", param);
        //    return data;
        //}
    }
}
