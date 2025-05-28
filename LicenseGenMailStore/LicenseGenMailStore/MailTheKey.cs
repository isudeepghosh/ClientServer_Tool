using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace LicenseGenMailStore
{
    class MailTheKey
    {
        public static string MailHtml(string key)
        {
            string mailBody = "<html><head><script type=\"text/javascript\" src=\"https://platform.linkedin.com/badges/js/profile.js\" async defer></script><meta http-equiv=\"content-type\" content=\"text/html; charset=ISO-8859-1\"></head><h3>Welcome to KeyGen</h3><p>&nbsp;</p><p>Thanks for using our software,Your key is bellow</p><p></p><p><span class=\"moz-signature\" style=\"color: #0000ff; background-color: #ffff00;\">"+key+"</span></p><div class=\"moz-signature\">Kindly use this key for one system, multiple system activation is not permissible.&nbsp;<em><em><br /> </em></em></div></p><div class=\"moz-signature\"><i><br><br>Regards,<br><div class=\"LI-profile-badge\"  data-version=\"v1\" data-size=\"medium\" data-locale=\"en_US\" data-type=\"horizontal\" data-theme=\"light\" data-vanity=\"sudeepghosh95\"><a class=\"LI-simple-link\" href='https://in.linkedin.com/in/sudeepghosh95?trk=profile-badge'>SuDeep Ghosh</a></div> <small>Microsoft Certified Technology Specialist</small><br></i></div></body></html>";



                return mailBody;
        }
        public static void Email(string key,string mailTo)
        {
            string htmlString = MailHtml(key);
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("codersudeepghosh@gmail.com");
                message.To.Add(new MailAddress(mailTo));
                message.Subject = "KeyGen: Mail containing key";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("codersudeepghosh@gmail.com", "PASSWORD");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
