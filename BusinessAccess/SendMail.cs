using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace BusinessAccess
{
    public class SendMail
    {
        public string SendEmail(string pEmailId, string pSubject, string pBodyMessage)
        {
            string emailResult = "";
            // string send_message = epay_id + ":" + message + ":" + amt;
            MailMessage mail = new MailMessage();
            mail.To.Add(pEmailId);
            mail.Subject = pSubject;
            mail.Body = pBodyMessage;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.EnableSsl = true;
            string pwd = "Divya@8772";            
            sc.Credentials = new NetworkCredential("sivaeedala@gmail.com", pwd);
            try
            {
                sc.Send(mail);
                emailResult = "suc";

            }
            catch (SmtpFailedRecipientsException recexc)
            {
                SmtpStatusCode statCode;
                for (int recipent = 0; recipent < recexc.InnerExceptions.Length - 1; recipent++)
                {
                    statCode = recexc.InnerExceptions[recipent].StatusCode;
                    emailResult = statCode.ToString();

                    if ((statCode == SmtpStatusCode.MailboxBusy) || (statCode == SmtpStatusCode.MailboxUnavailable))
                    {
                        System.Threading.Thread.Sleep(5000);
                        sc.Send(mail);
                    }
                }
            }
            catch (SmtpException sexc)
            {
                emailResult = sexc.Message + sexc.ToString();
            }

            catch (Exception ex)
            {
                emailResult = ex.Message + ex.ToString();
            }
            return emailResult;
        }
    }
}
