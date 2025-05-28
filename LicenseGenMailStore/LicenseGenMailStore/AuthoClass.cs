using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LicenseGenMailStore
{
    class AuthoClass
    {
        static string secretKey = "JBSWY3DPEHPK3PXP";
        public static void authenticateMain()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                  Welcome to KeyGenLic AdminTool Authenticator");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Kindly Authenticate");
            Console.ResetColor();
            Console.WriteLine("Enter 1: Authenticate using two-factor authentication (2FA)");
            Console.WriteLine("Enter 2: Authenticate using OTP from Mail");

            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int OptionAuth = int.Parse(Console.ReadLine());
            if (OptionAuth == 1)
            {
                Program.Authy = AuthoClass.authenticate2FA();
            }
            else
            {
                Program.Authy = AuthoClass.authenticateOTPMail();
            }

        }
        public static bool authenticateOTPMail()
        {
            var spinner = new Spinner(10, 10);

            spinner.Start();
            
            Random rnd = new Random();
            int key = rnd.Next(1111, 9999);
            string mailBody = "<div><h3>Welcome to KeyGenAdmin Tool</h3></div><div><p>&nbsp;</p></div><div><p style=\"text-align: center;\">Thanks for using our software,Your OTP for Authentication the Tool is bellow</p></div><div style=\"text-align: center;\"><p><span class=\"\\&quot;moz-signature\\&quot;\">" + key + "</span></p></div><div><div class=\"\\&quot;moz-signature\\&quot;\" style=\"text-align: center;\">OTP will valid for one time only.&nbsp;<em><em><br /> </em></em></div></div><div><div class=\"\\&quot;moz-signature\\&quot;\"><em><em><br /><br />Regards,<br /></em></em><div class=\"\\&quot;LI-profile-badge\\&quot;\" data-version=\"\\&quot;v1\\&quot;\" data-size=\"\\&quot;medium\\&quot;\" data-locale=\"\\&quot;en_US\\&quot;\" data-type=\"\\&quot;horizontal\\&quot;\" data-theme=\"\\&quot;light\\&quot;\" data-vanity=\"\\&quot;sudeepghosh95\\&quot;\"><a class=\"\\&quot;LI-simple-link\\&quot;\" href=\"https://in.linkedin.com/in/sudeepghosh95?trk=profile-badge\">SuDeep Ghosh</a></div><small></small></div><div class=\"\\&quot;moz-signature\\&quot;\"><em><small>Contact: (+91) 9531688695</small></em></div><div class=\"\\&quot;moz-signature\\&quot;\"><em><small>Microsoft Certified Technology Specialist</small><br /></em></div></div>";
                try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("codersudeepghosh@gmail.com");
                message.To.Add(new MailAddress("sudeepghosh95@gmail.com"));
                message.Subject = "KeyGenAdminTool: Mail containing OTP";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = mailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("codersudeepghosh@gmail.com", "PASSWORD");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
            spinner.Stop();

            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                  Welcome to KeyGenLic AdminTool Authenticator");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("OTP is generated and mailed to Admin");
            Console.WriteLine();
            Console.Write("Enter OTP from Admin mail <su******95@gmail.com>: ");
            string userCode = Console.ReadLine();
            if (userCode == "")
            {
                return false;
            }
            else if(userCode.Equals(key))
            {
                Console.WriteLine("Success!");
                return true;
            }
            else
            {
                Console.WriteLine("Failed. Try again!");
                return false;
            }
        }
        public static bool authenticate2FA()
        {
            var bytes = Base32Encoding.ToBytes(secretKey);
            var totp = new Totp(bytes);
            while (true)
            {
                Console.Write("Enter code from Any Authenticator app: ");
                string userCode = Console.ReadLine();
                if (userCode == "")
                {
                    return false;
                }
                //Generate one time token code
                string tokenInApp = totp.ComputeTotp();
                int remainingSeconds = totp.RemainingSeconds();
                if (userCode.Equals(tokenInApp)
                    && remainingSeconds > 0)
                {
                    Console.WriteLine("Success!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed. Try again!");
                }
            }
        }

    }
    public class Spinner : IDisposable
    {
        private const string Sequence = @"/-\|";
        private int counter = 0;
        private readonly int left;
        private readonly int top;
        private readonly int delay;
        private bool active;
        private readonly Thread thread;

        public Spinner(int left, int top, int delay = 100)
        {
            this.left = left;
            this.top = top;
            this.delay = delay;
            thread = new Thread(Spin);
        }

        public void Start()
        {
            active = true;
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop()
        {
            active = false;
            Draw(' ');
        }

        private void Spin()
        {
            while (active)
            {
                Turn();
                Thread.Sleep(delay);
            }
        }

        private void Draw(char c)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(c);
        }

        private void Turn()
        {
            Draw(Sequence[++counter % Sequence.Length]);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
