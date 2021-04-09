using Device_BE.DTO;
using Device_BE.Management;
using Device_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/khos")]
    [ApiController]
    public class KhosController : ControllerBase
    {
        private readonly QLPhoneContext _context;
        public KhosController(QLPhoneContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("GetTonKho")]
        public ListView<TonKhoDAO> GetTonKho(Dictionary<string, object> param)
        {
            ListView<TonKhoDAO> view = new ListView<TonKhoDAO>();
            CallProcedure<TonKhoDAO> call = new CallProcedure<TonKhoDAO>(_context);
            view.List = call.BaoCao("bao_cao_ton_kho", param , out int total);
            view.total = total;
            return view;
        }


        [HttpGet]
        [Route("getPage")]
        public ListSelect getPage(string Search, int PageIndex, int PageSize)
            {
            ListSelect list = new ListSelect();
            var data = _context.Dmkho.ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                data = data.Where(x => x.Ten.ToLower().Contains(Search)).ToList();
            }
            list.total = data.Count;
            list.List = data.OrderBy(x => x.Ten).Skip((PageIndex) * PageSize).Take(PageSize).ToList();
            return list;
        }
        [HttpGet]
        [Route("getAllKho")]
        public ActionResult getAllKho()
        {
            var data = _context.Dmkho.ToList();
            return Ok(data.Select(x => new
            {
                Id = x.Id,
                Ten = x.Ten
            }));
        }
        [HttpPost]
        public ActionResult Create(Dmkho model)
        {
            model.Id = Guid.NewGuid();
            _context.Dmkho.Add(model);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(Dmkho model)
        {
            var data = _context.Dmkho.Find(model.Id);
            data.Active = model.Active;
            data.Ten = model.Ten;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = await _context.Dmkho.FindAsync(id);
            if (delete == null)
            {
                return Ok("Xóa Không thành công");
            }
            _context.Dmkho.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
