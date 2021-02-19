using Device_BE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApi.Func;
namespace Device_BE.Controllers
{
    [Route("api/anh")]
    [ApiController]
    public class DMAnhController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public DMAnhController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult getAnh(Guid id)
        {
            var data = _context.Dmanh.Where(x => x.AnhId.Equals(id)).ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("get/{anh}")]
        public ActionResult getAnh(string anh)
        {
            var dir = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), dir);
            var path = Path.Combine(pathToSave, anh);
            //... add content to the stream.
            return File(System.IO.File.OpenRead(path), "image/*");
            
           
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost]
        [Route("Save")]
        public ActionResult SaveToDataBase(Dmanh model)
        {
            model.Id = Guid.NewGuid();
            model.ImageUrl = "Resources/image/" + model.Ten;
            var sanpham = model.CopyAs<Dmanh>();
            _context.Dmanh.Add(sanpham);
            _context.SaveChanges();
            return NoContent();
        }
       
    }
}
