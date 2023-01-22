using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public static class Email
    {
        public static bool MailGonder(string alici, string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("z35@vosvosbilisim.com");
            ePosta.To.Add(alici); //göndereceğimiz mail adresi

            ePosta.Subject = konu; //mail konusu
            ePosta.Body = icerik; //mail içeriği 

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("z35@vosvosbilisim.com", "iskur35");
            client.Port = 25;
            client.Host = "mail.vosvosbilisim.com";
            client.EnableSsl = false;

            object userState = true;
            bool kontrol = true;
            try
            {
                client.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;

            }
            return kontrol;
        }
    }
}
