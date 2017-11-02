using System.Net;
using System.Net.Mail;

namespace Teaco
{
    public class SendMail
    {
        public void Mail()
        {
            MailAddress fromMailAddress = new MailAddress("boteplaza@gmail.com", "Test");
            MailAddress toAddress = new MailAddress("merikanov94@mail.ru", "Uncle Bob");
            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "Отчет по автотестированию Teaco";
                mailMessage.Body = "Откройте документ";
                //прикрепляем вложение
                Attachment attData = new Attachment("C:/Users/r.merikanov/source/repos/TeacoTest/TeacoTest/bin/Debug/Test.xlsx");
                mailMessage.Attachments.Add(attData);

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "123456eplaza");
                smtpClient.Send(mailMessage);
            }
        }
    }
}
