using Device_BE.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Device_BE.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private static readonly string _from = "cuongnb3698@gmail.com"; // Email của Sender (của bạn)
        private static readonly string _pass = "Cuong3698"; // Mật khẩu Email của Sender (của bạn)
        [HttpPost]
        public ActionResult Send(EmailModel model)
        {
            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin l�-i
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(_from);
                mail.To.Add(model.Email);
                mail.Subject = model.TieuDe;
                mail.IsBodyHtml = true;
                mail.Body = model.NoiDung;

                mail.Priority = MailPriority.High;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
