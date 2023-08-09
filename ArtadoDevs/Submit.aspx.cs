using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtadoDevs
{
    public partial class Submit : System.Web.UI.Page
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
        HttpCookie old = HttpContext.Current.Request.Cookies["id"];
        SqlConnection baglanti = new SqlConnection();

        Random random = new Random();
        Random random1 = new Random();
        static int securityCode;
        int passid1;
        static int passid2;

        static string username;
        static string password;
        static string mail;
        static string bio;
        static string site;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (old != null)
            {
                Response.Redirect("/devs/panel");
            }
            passid1 = random.Next(1000, 99999999);

            baglanti.ConnectionString = con;

            if (baglanti.State.ToString() == "Open")
            {
                baglanti.Close();
                SqlConnection.ClearPool(baglanti);
            }

            Uyarı.Text = "";

            string mode = Request.QueryString["mode"];
            switch (mode)
            {
                case "register":
                    register.Visible = true;
                    login.Visible = false;
                    Mail_Onay.Visible = false;
                    r_button.Visible = true;
                    l_button.Visible = true;
                    a_button.Visible = false;
                    a_button2.Visible = false;
                    re_button.Visible = false;
                    break;
                case "login":
                    register.Visible = false;
                    login.Visible = true;
                    Mail_Onay.Visible = false;
                    r_button.Visible = true;
                    l_button.Visible = true;
                    a_button.Visible = false;
                    a_button2.Visible = false;
                    re_button.Visible = false;
                    break;
                default:
                    register.Visible = true;
                    login.Visible = false;
                    Mail_Onay.Visible = false;
                    r_button.Visible = true;
                    l_button.Visible = true;
                    a_button.Visible = false;
                    a_button2.Visible = false;
                    re_button.Visible = false;
                    break;
            }
        }
        #region Register
        protected void Register(object sender, EventArgs e)
        {
            string mode = Request.QueryString["mode"];

            if (mode == "login")
            {
                Response.Redirect("/Submit?mode=register");
            }
            else
            {
                baglanti.ConnectionString = con;

                if (Username.Value == string.Empty || Mail.Value == string.Empty || pass.Value == string.Empty || Bio.Value == string.Empty || Site.Value == string.Empty)
                {
                    Uyarı.Visible = true;
                    Uyarı.Text = "Lütfen tüm alanların dolu olduğundan emin olun.";
                }
                else
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    SqlCommand control = new SqlCommand("select * from artadoco_admin.Devs where Name='" + Username.Value.Replace("'", "\'").Replace('"', '\"') + "' or Mail='" + Mail.Value.Replace("'", "\'").Replace('"', '\"') + "'", baglanti);
                    SqlDataReader reading = control.ExecuteReader();

                    if (reading.Read())
                    {
                        Uyarı.Visible = true;
                        Uyarı.Text = "Bu kullanıcı adı veya e-posta adresi alınmış.";
                    }
                    else
                    {

                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        username = Username.Value.Replace("'", "\'").Replace('"', '\"');
                        password = pass.Value.Replace("'", "\'").Replace('"', '\"');
                        mail = Mail.Value.Replace("'", "\'").Replace('"', '\"');
                        bio = Bio.Value.Replace("'", "\'").Replace('"', '\"');
                        site = Site.Value.Replace("'", "\'").Replace('"', '\"');

                        securityCode = random1.Next(100000, 999999);

                        //Mail Confirmation
                        MailSend(true, Mail.Value.Replace("'", "\'").Replace('"', '\"'));

                        register.Visible = false;
                        Mail_Onay.Visible = true;
                        r_button.Visible = false;
                        l_button.Visible = false;
                        a_button.Visible = true;
                        a_button2.Visible = false;
                        re_button.Visible = true;
                    }
                }
            }
        }
        #endregion

        #region  Login
        protected void Login(object sender, EventArgs e)
        {
            string mode = Request.QueryString["mode"];
            SqlCommand komut;
            if (mode == "login")
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                string sorgusalt = "SELECT Salt from artadoco_admin.Devs where Mail='" + email.Value.Replace("'", "\'").Replace('"', '\"') + "' ";
                string salt;
                komut = new SqlCommand(sorgusalt, baglanti);
                salt = (string)komut.ExecuteScalar();

                if (salt == null)
                {
                    Uyarı.Visible = true;
                    Uyarı.Text = "E-posta adresi veya şifre yanlış!";
                    register.Visible = true;
                    login.Visible = false;
                    Mail_Onay.Visible = false;
                    r_button.Visible = true;
                    l_button.Visible = true;
                    a_button.Visible = false;
                    re_button.Visible = false;
                }
                else
                {
                    string sorgu = "select Password from artadoco_admin.Devs where Mail='" + email.Value.Replace("'", "\'").Replace('"', '\"') + "' and Password='" + SecurityHelper.HashPassword(password_l.Value.Replace("'", "\'").Replace('"', '\"'), salt, 10101, 70) + "'";
                    string password;
                    komut = new SqlCommand(sorgu, baglanti);
                    password = (string)komut.ExecuteScalar();

                    if (password != null)
                    {
                        string pwdHashed;

                        pwdHashed = SecurityHelper.HashPassword(password_l.Value.Replace("'", "\'").Replace('"', '\"'), salt, 10101, 70);

                        if (password == pwdHashed)
                        {
                            if (baglanti.State == ConnectionState.Closed)
                            {
                                baglanti.Open();
                            }

                            securityCode = random1.Next(100000, 999999);

                            //Mail Confirmation
                            MailSend(false, email.Value);

                            register.Visible = false;
                            login.Visible = false;
                            Mail_Onay.Visible = true;
                            r_button.Visible = false;
                            l_button.Visible = false;
                            a_button.Visible = false;
                            a_button2.Visible = true;
                            re_button.Visible = true;
                        }
                        else
                        {
                            Uyarı.Visible = true;
                            Uyarı.Text = "Kullanıcı adı veya şifre yanlış!";
                            register.Visible = true;
                            login.Visible = false;
                            Mail_Onay.Visible = false;
                            r_button.Visible = true;
                            l_button.Visible = true;
                            a_button.Visible = false;
                            re_button.Visible = false;
                        }
                    }
                    else
                    {
                        Uyarı.Visible = true;
                        Uyarı.Text = "Kullanıcı adı veya şifre yanlış!";
                        register.Visible = true;
                        login.Visible = false;
                        Mail_Onay.Visible = false;
                        r_button.Visible = true;
                        l_button.Visible = true;
                        a_button.Visible = false;
                        re_button.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("/Submit?mode=login");
            }
        }
        #endregion
        public void MailSend(bool register, string mail)
        {
            if (register)
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "Confirm Your Account - Artado Developers";
                msg.From = new MailAddress("support@artadosearch.com", "Artado");
                msg.To.Add(new MailAddress(mail));
                msg.IsBodyHtml = true;
                msg.Body = "<td style=\"text-align:center\"><h5>Your Artado Developers confirmation code:</h5><h4>" + securityCode + "</h4></td>";

                SmtpClient smtp = new SmtpClient("mail.artadosearch.com", 587);
                NetworkCredential AccountInfo = new NetworkCredential("support@artadosearch.com", "ardam14252023@com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(msg);
                }
                catch
                {
                    Uyarı.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz.";
                }
            }
            else
            {
                string browser = Request.Browser.Browser;
                string ip = Request.UserHostAddress;

                MailMessage msg = new MailMessage();
                msg.Subject = "Your Account Has Been Logged In - Artado Developers";
                msg.From = new MailAddress("support@artadosearch.com", "Artado");
                msg.To.Add(new MailAddress(mail));
                msg.IsBodyHtml = true;
                msg.Body = "<td style=\"text-align:center\"><h5>Your Artado Developers Account was logged in from:</h5><h4>" + "Browser: " + browser + "<br/> IP Address: " + ip + "<br/> <h5>Please use this code to confirm that you are the one logged in:</h5><h4>" + securityCode + "</h4> <h6>If you're not the one who logged in, change your password.</h6> </td>";

                SmtpClient smtp = new SmtpClient("mail.artadosearch.com", 587);
                NetworkCredential AccountInfo = new NetworkCredential("support@artadosearch.com", "ardam14252023@com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(msg);
                }
                catch (Exception err)
                {
                    Uyarı.Text = "Onay kodu gönderilirken bir sıkıntı oluştu. E-posta adresinizi kontrol edip lütfen tekrar deneyiniz." + "<br/>" + err;
                }
            }
        }

        protected void Resend(object sender, EventArgs e)
        {
            securityCode = random1.Next(100000, 999999);
            //Mail Confirmation
            MailSend(true, Mail.Value);
        }

        protected void Accept(object sender, EventArgs e)
        {
            if (code.Value == securityCode.ToString())
            {
                passid2 = passid1;
                string salt = SecurityHelper.GenerateSalt(70);
                string pwdHashed = SecurityHelper.HashPassword(password, salt, 10101, 70);
                string url = username.Replace(" ", "_");

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();
                }
                HttpCookie cookie = new HttpCookie("id");
                cookie.Value = EncryptClass.Encrypt(passid2.ToString());
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
                string istek = "insert into artadoco_admin.Devs(Name, Password, Mail, Description, URL, WebSite, Logo, PassID, Salt, Validation) values (@Name, @Password, @Mail, @Description, @URL, @WebSite, @Logo, @PassID, @Salt, @Validation)";
                SqlCommand cmd = new SqlCommand(istek, baglanti);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@Password", pwdHashed);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@Mail", mail);
                cmd.Parameters.AddWithValue("@Description", bio);
                cmd.Parameters.AddWithValue("@URL", url);
                cmd.Parameters.AddWithValue("@WebSite", site);
                cmd.Parameters.AddWithValue("@PassID", passid2);
                cmd.Parameters.AddWithValue("@Logo", "image.png");
                cmd.Parameters.AddWithValue("@Validation", "true");
                cmd.ExecuteNonQuery();

                Response.Redirect("/devs/panel");
            }
            else
            {
                Uyarı.Text = "Kod yanlış lütfen tekrar deneyiniz!";
                register.Visible = false;
                Mail_Onay.Visible = true;
                r_button.Visible = false;
                l_button.Visible = false;
                a_button.Visible = true;
                re_button.Visible = true;
            }
        }

        protected void Login_Accept(object sender, EventArgs e)
        {
            if (code.Value == securityCode.ToString())
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                string sorgu = "SELECT PassID FROM artadoco_admin.Devs where Mail='" + email.Value.Replace("'", "\'").Replace('"', '\"') + "'";
                int id;
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                id = (int)komut.ExecuteScalar();

                if (old != null && old.Value != null)
                {
                    old.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(old);
                    Session.Abandon();
                }
                HttpCookie cookie = new HttpCookie("id");
                cookie.Value = EncryptClass.Encrypt(id.ToString());
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);

                Response.Redirect("/devs/panel");
            }
            else
            {
                Uyarı.Text = "Kod yanlış. Lütfen tekrar deneyiniz!";
                register.Visible = false;
                Mail_Onay.Visible = true;
                r_button.Visible = false;
                l_button.Visible = false;
                a_button.Visible = true;
                re_button.Visible = true;
            }
        }
        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }
    }
}