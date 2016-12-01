using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace ElectronicSchoolDiary
{
 

    class Email
    {
        public void SendEmailInBackground(string SchoolMail, string SchoolName, string SchoolMailPassword, string currentParentEmail, string currentParentName)

        {
            try
            {
                var fromAddress = new MailAddress(SchoolMail, SchoolName);
                string fromPassword = SchoolMailPassword;
                var toAddress = new MailAddress(currentParentEmail, currentParentName);
               

                string subject = "test";
                string body = "Hey now!!";


                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                Thread T1 = new Thread(delegate ()
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        {
                            try
                            {
                                smtp.Send(message);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                           
                        }
                    }
                });

                T1.Start();
                MessageBox.Show("Email uspjesno poslat!");
               
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }
    

    }
}
