using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/anh")]
    [ApiController]
    public class DMAnhController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult Post([FromBody] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string path = Directory.GetCurrentDirectory() + "\\Resources\\Images\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fs = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                        return Ok("Ok");
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
