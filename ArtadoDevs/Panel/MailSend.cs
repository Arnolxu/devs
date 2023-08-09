using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace ArtadoDevs
{
    public class MailSend
    {
        public static void Send(bool register, string mail, System.Web.UI.WebControls.Panel warn, string browser, string ip, int code)
        {
            string user = System.Configuration.ConfigurationManager.AppSettings["MailUser"].ToString();
            string pass = System.Configuration.ConfigurationManager.AppSettings["MailPassword"].ToString();
            if (register == true) //Checks if the user is logging in or registering
            {
                //Register
                MailMessage msg = new MailMessage();
                msg.Subject = "Confirm Your Account - Artado Developers";
                msg.From = new MailAddress("support@artadosearch.com", "Artado");
                msg.To.Add(new MailAddress(mail));
                msg.IsBodyHtml = true;
                msg.Body = "<td style=\"text-align:center\"><h5>Your Artado MyAccount confirmation code:</h5><h4>" + code + "</h4></td>";

                SmtpClient smtp = new SmtpClient("mail.artadosearch.com", 587);
                NetworkCredential AccountInfo = new NetworkCredential(user, pass);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(msg);
                }
                catch
                {
                    warn.Visible = true;
                }
            }
            else
            {
                //Login
                MailMessage msg = new MailMessage();
                msg.Subject = "Your Account Has Been Logged In - Artado Developers";
                msg.From = new MailAddress("support@artadosearch.com", "Artado");
                msg.To.Add(new MailAddress(mail));
                msg.IsBodyHtml = true;
                msg.Body = "<td style=\"text-align:center\"><h5>Your Artado Developers Account was logged in from:</h5><h4>" + "Browser: " + browser + "<br/> IP Address: " + ip + "<br/> <h5>Please use this code to confirm that you are the one logged in:</h5><h4>" + code + "</h4> <h6>If you're not the one who logged in, change your password.</h6> </td>";

                SmtpClient smtp = new SmtpClient("mail.artadosearch.com", 587);
                NetworkCredential AccountInfo = new NetworkCredential(user, pass);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(msg);
                }
                catch // catch (Exception err)
                {
                    warn.Visible = true;
                }
            }
        }
    }
}