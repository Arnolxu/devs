using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ArtadoDevs.Panel
{
    internal class Interactions
    {
        public static void UploadProduct(bool update, FileUpload fileupload, string platform, System.Web.UI.WebControls.Panel danger, Label dangertxt, string column, int id, string version)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            FileInfo fileinfo = new FileInfo(fileupload.FileName);
            string filename = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
            filename += "-" + platform + "-" + Guid.NewGuid().ToString().Replace("-", "") + fileinfo.Extension;
            fileupload.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Upload/Products/" + filename));

            var scanner = new AntiVirus.Scanner();
            string result = scanner.ScanAndClean(System.Web.HttpContext.Current.Server.MapPath("/Upload/Products/" + filename)).ToString();

            if (result == "VirusFound")
            {
                danger.Visible = true;
                dangertxt.Text = "Yüklediğiniz dosya virüs olarak algılandı!";
            }
            else if (result == "FileNotExist")
            {
                danger.Visible = true;
                dangertxt.Text = "Bir hata oluştu! Dosya bulunamadı.";
            }
            else
            {
                string istek = "insert into artadoco_admin.Versions(ProductID, VersionNum, OS, Status, Path) values (@ProductID, @VersionNum, @OS, @Status, @Path)";
                SqlCommand cmd = new SqlCommand(istek, baglanti);
                cmd.Parameters.AddWithValue("@ProductID", id);
                cmd.Parameters.AddWithValue("@VersionNum", version);
                cmd.Parameters.AddWithValue("@OS", column);
                cmd.Parameters.AddWithValue("@Status", "Waiting");
                cmd.Parameters.AddWithValue("@Path", "/Upload/Products/" + filename);
                cmd.ExecuteNonQuery();

                if(update == false)
                {
                    int ver_id = ArtadoSql.SelectInt("ID", "Versions", "ProductID", id + "' and VersionNum='" + version + "' and OS='" + column, con);

                    istek = "update artadoco_admin.Products set " + column + "='" + ver_id + "' where ID='" + id + "'";
                    SqlCommand command = new SqlCommand(istek, baglanti);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string UploadImage(FileUpload fileupload)
        {
            FileInfo fileinfo = new FileInfo(fileupload.FileName);
            string filename = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
            filename +=  Guid.NewGuid().ToString().Replace("-", "") + fileinfo.Extension;
            fileupload.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + filename));

            var scanner = new AntiVirus.Scanner();
            string result = scanner.ScanAndClean(System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + filename)).ToString();

            if (result == "VirusFound")
            {
                return result;
            }
            else if (result == "FileNotExist")
            {
                return result;
            }
            else
            {
                return filename;
            }
        }

        public static void Share_Action(string status, string devname, string devurl, string publish, string name, string description, string type, string genre, string version, FileUpload logo, FileUpload cover, FileUpload shots, string video, FileUpload win, FileUpload linux, FileUpload mac, FileUpload android, FileUpload bsd, FileUpload haiku, HtmlControl sharepanel, System.Web.UI.WebControls.Panel danger, Label dangertxt)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            try
            {
                string logoname = UploadImage(logo);
                if (logoname == "VirusFound")
                {
                    danger.Visible = true;
                    dangertxt.Text = "Yüklediğiniz dosya virüs olarak algılandı!";
                }
                else if (logoname == "FileNotExist")
                {
                    danger.Visible = true;
                    dangertxt.Text = "Bir hata oluştu! Dosya bulunamadı.";
                }
                else
                {
                    string covername = UploadImage(cover);
                    if (covername == "VirusFound")
                    {
                        danger.Visible = true;
                        dangertxt.Text = "Yüklediğiniz dosya virüs olarak algılandı!";
                    }
                    else if (covername == "FileNotExist")
                    {
                        danger.Visible = true;
                        dangertxt.Text = "Bir hata oluştu! Dosya bulunamadı.";
                    }
                    else if(shots.PostedFiles.Count <= 5)
                    {
                        List<string> images = new List<string>();

                        if (shots.HasFiles)
                        {
                            foreach (HttpPostedFile uploadedFile in shots.PostedFiles)
                            {
                                FileInfo fileinfo = new FileInfo(uploadedFile.FileName);
                                string filename = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
                                filename += Guid.NewGuid().ToString().Replace("-", "") + fileinfo.Extension;
                                shots.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + filename));
                                images.Add(filename);
                            }
                        }

                        string url = name.Replace(" ", "_");

                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }

                        string istek = "insert into artadoco_admin.Products(Name, Description, Developer, Type, Genre, Price, AppStatus, DevStatus, URL, DevID, Logo, Cover, Image1, Image2, Image3, Image4, Image5, Downloads, Views, Comments, Gameplay) values (@Name, @Description, @Developer, @Type, @Genre, @Price, @AppStatus, @DevStatus, @URL, @DevID, @Logo, @Cover, @Image1, @Image2, @Image3, @Image4, @Image5, @Downloads, @Views, @Comments, @Gameplay)";
                        SqlCommand cmd = new SqlCommand(istek, baglanti);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Developer", devname);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Genre", genre);
                        cmd.Parameters.AddWithValue("@Price", 0); //Artado Store doesn't support payment yet. That's why Price will save as 0 during beta
                        cmd.Parameters.AddWithValue("@AppStatus", status);
                        cmd.Parameters.AddWithValue("@DevStatus", publish);
                        cmd.Parameters.AddWithValue("@URL", url);
                        cmd.Parameters.AddWithValue("@DevID", devurl);
                        cmd.Parameters.AddWithValue("@Logo", logoname);
                        cmd.Parameters.AddWithValue("@Cover", covername);
                        cmd.Parameters.AddWithValue("@Image1", images[0]);
                        if (images.Count > 1)
                        {
                            cmd.Parameters.AddWithValue("@Image2", images[1]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image2", DBNull.Value);
                        }
                        if (images.Count > 2)
                        {
                            cmd.Parameters.AddWithValue("@Image3", images[2]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image3", DBNull.Value);
                        }
                        if (images.Count > 3)
                        {
                            cmd.Parameters.AddWithValue("@Image4", images[3]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image4", DBNull.Value);
                        }
                        if (images.Count > 4)
                        {
                            cmd.Parameters.AddWithValue("@Image5", images[4]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image5", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@Downloads", 0);
                        cmd.Parameters.AddWithValue("@Views", 0);
                        cmd.Parameters.AddWithValue("@Comments", 0);
                        cmd.Parameters.AddWithValue("@Gameplay", video);
                        cmd.ExecuteNonQuery();

                        int id = ArtadoSql.SelectInt("ID", "Products", "Name", name + "' and Developer='" + devname, con);

                        if (win.HasFile)
                        {
                            UploadProduct(false, win, "win", danger, dangertxt, "WinFolder", id, version);
                        }
                        if (linux.HasFile)
                        {
                            UploadProduct(false, linux, "linux", danger, dangertxt, "LinuxFolder", id, version);
                        }
                        if (mac.HasFile)
                        {
                            UploadProduct(false, mac, "mac", danger, dangertxt, "MacFolder", id, version);
                        }
                        if (android.HasFile)
                        {
                            UploadProduct(false, android, "android", danger, dangertxt, "AndroidFolder", id, version);
                        }
                        if (bsd.HasFile)
                        {
                            UploadProduct(false, bsd, "bsd", danger, dangertxt, "BSDFolder", id, version);
                        }
                        if (haiku.HasFile)
                        {
                            UploadProduct(false, haiku, "haiku", danger, dangertxt, "HaikuFolder", id, version);
                        }


                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                    }
                }
            }
            catch
            {
                sharepanel.Visible = true;
                danger.Visible = true;
                dangertxt.Text = "Bir hata oluştu! Lütfen tüm zorunlu alanları düzgün doldurduğunuzdan emin olunuz.";
            }
        }

        public static void Share(string status, string devname, string devurl, string publish, string name, string description, string type, string genre, string version, FileUpload logo, FileUpload cover, FileUpload shots, string video, FileUpload win, FileUpload linux, FileUpload mac, FileUpload android, FileUpload bsd, FileUpload haiku, HtmlControl sharepanel, System.Web.UI.WebControls.Panel danger, Label dangertxt)
        {
            if(status == "Saved")
            {
                if (devname != null || devurl != null || publish != null || name != null && logo.HasFile  == true || description != null || genre != null || cover.HasFile == true || (shots.HasFiles == true || shots.HasFile == true || shots.PostedFiles.Count < 5) || (win.HasFile == true || linux.HasFile == true || mac.HasFile == true || android.HasFile == true || bsd.HasFile == true || haiku.HasFile == true))
                {
                    //Connection Strings
                    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

                    //Setting Sql Connection
                    SqlConnection sqlcon = new SqlConnection(con);

                    if (ArtadoSql.Select("Name", "Products", "Name", name + "' and Developer='" + devname, con, "string") != null)
                    {
                        sharepanel.Visible = true;
                        danger.Visible = true;
                        dangertxt.Text = "Bu ad daha önce alınmış!";
                    }
                    else
                    {
                        Share_Action(status, devname, devurl, publish, name, description, type, genre, version, logo, cover, shots, video, win, linux, mac, android, bsd, haiku, sharepanel, danger, dangertxt);
                    }
                }
                else
                {
                    sharepanel.Visible = true;
                    danger.Visible = true;
                    dangertxt.Text = "Bir hata oluştu! Lütfen tüm zorunlu alanları doldurduğunuzdan emin olunuz.";
                }
            }
            else
            {
                if (publish == "In-development")
                {
                    if (devname != null && devurl != null && publish != null && name != null && description != null && genre != null && logo.HasFile == true && cover.HasFile == true)
                    {
                        Share_Action(status, devname, devurl, publish, name, description, type, genre, version, logo, cover, shots, video, win, linux, mac, android, bsd, haiku, sharepanel, danger, dangertxt);
                    }
                    else
                    {
                        sharepanel.Visible = true;
                        danger.Visible = true;
                        dangertxt.Text = "Bir hata oluştu! Lütfen tüm zorunlu alanları doldurduğunuzdan emin olunuz.";
                    }
                }
                else
                {
                    if (devname != null && devurl != null && publish != null && name != null && description != null && genre != null && logo.HasFile == true && cover.HasFile == true && (shots.HasFiles == true || shots.HasFile == true && shots.PostedFiles.Count < 5) && (win.HasFile == true || linux.HasFile == true || mac.HasFile == true || android.HasFile == true || bsd.HasFile == true || haiku.HasFile == true))
                    {
                        Share_Action(status, devname, devurl, publish, name, description, type, genre, version, logo, cover, shots, video, win, linux, mac, android, bsd, haiku, sharepanel, danger, dangertxt);
                    }
                    else
                    {
                        sharepanel.Visible = true;
                        danger.Visible = true;
                        dangertxt.Text = "Bir hata oluştu! Lütfen tüm zorunlu alanları doldurduğunuzdan emin olunuz.";
                    }
                }
            }
        }

        public static void Update(string id, string status, string devname, string devurl, string publish, string name, string description, string type, string genre, string version, FileUpload logo, FileUpload cover, FileUpload shots, string video, FileUpload win, FileUpload linux, FileUpload mac, FileUpload android, FileUpload bsd, FileUpload haiku, HtmlControl sharepanel, System.Web.UI.WebControls.Panel danger, Label dangertxt)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection connect = new SqlConnection(con);

            //URL
            string url = name.Replace(" ", "_");

            string get_status = ArtadoSql.Select("Status" , "Products", "ID",  id, con, "string");

            if(get_status == "Approved")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    //Update Infos
                    string query = "update Products " +
                                   "set AppStatus='" + status.Replace("'","\'").Replace('"','\"') + 
                                   "', Name='" + name.Replace("'","\'").Replace('"','\"') + 
                                   "', Description='" + description.Replace("'","\'").Replace('"','\"') + 
                                   "', Genre='" + genre.Replace("'","\'").Replace('"','\"') +
                                   "', DevStatus='" + publish.Replace("'","\'").Replace('"','\"') +
                                   "', URL='" + url.Replace("'","\'").Replace('"','\"') + 
                                   "', Gameplay='" + video.Replace("'","\'").Replace('"','\"') + 
                                   "' where ID='" + id.Replace("'","\'").Replace('"','\"') + "'";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    //Update Logo
                    if (logo.HasFile)
                    {
                        //Delete old logo
                        string old_logo = ArtadoSql.Select("Logo", "Products", "ID", id, con, "string");
                        string path = System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + old_logo);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//checks if old profile pic exist or not  
                        {
                            file.Delete();
                        }

                        string logoname = UploadImage(logo);
                        if (logoname == "VirusFound")
                        {
                            danger.Visible = true;
                            dangertxt.Text = "Yüklediğiniz dosya virüs olarak algılandı!";
                        }
                        else if (logoname == "FileNotExist")
                        {
                            danger.Visible = true;
                            dangertxt.Text = "Bir hata oluştu! Dosya bulunamadı.";
                        }
                        else
                        {
                            ArtadoSql.Update("Logo", logoname, "Products", "ID", id, con);
                        }
                    }

                    //Update Cover
                    if (cover.HasFile)
                    {
                        //Delete old cover
                        string old_cover = ArtadoSql.Select("Cover", "Products", "ID", id, con, "string");
                        string path = System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + old_cover);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//checks if old profile pic exist or not  
                        {
                            file.Delete();
                        }

                        string covername = UploadImage(cover);
                        if (covername == "VirusFound")
                        {
                            danger.Visible = true;
                            dangertxt.Text = "Yüklediğiniz dosya virüs olarak algılandı!";
                        }
                        else if (covername == "FileNotExist")
                        {
                            danger.Visible = true;
                            dangertxt.Text = "Bir hata oluştu! Dosya bulunamadı.";
                        }
                        else
                        {
                            ArtadoSql.Update("Cover", covername, "Products", "ID", id, con);
                        }
                    }

                    if(shots.HasFile || shots.HasFiles)
                    {
                        if(shots.PostedFiles.Count <= 5)
                        {
                            List<string> images = new List<string>();

                            foreach (HttpPostedFile uploadedFile in shots.PostedFiles)
                            {
                                FileInfo fileinfo = new FileInfo(uploadedFile.FileName);
                                string filename = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
                                filename += Guid.NewGuid().ToString().Replace("-", "") + fileinfo.Extension;
                                shots.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Upload/Images/" + filename));
                                images.Add(filename);
                            }

                            ArtadoSql.Update("Image1", images[0], "Products", "ID", id, con);
                            if (images.Count > 1)
                            {
                                ArtadoSql.Update("Image2", images[1], "Products", "ID", id, con);
                            }
                            if (images.Count > 2)
                            {
                                ArtadoSql.Update("Image3", images[2], "Products", "ID", id, con);
                            }
                            if (images.Count > 3)
                            {
                                ArtadoSql.Update("Image4", images[3], "Products", "ID", id, con);
                            }
                            if (images.Count > 4)
                            {
                                ArtadoSql.Update("Image5", images[4], "Products", "ID", id, con);
                            }
                        }
                        else
                        {
                            danger.Visible = true;
                            dangertxt.Text = "Maksimum 5 tane ekran görünütüsü yükleyebilirsiniz.";
                        }
                    }

                    connect.Close();
                }
                catch
                {
                    sharepanel.Visible = true;
                    danger.Visible = true;
                    dangertxt.Text = "Bir hata oluştu!";
                }
            }
        }


        public static void CreateAPI(string name, string url, string devname, string devid, string type, HtmlControl sharepanel, System.Web.UI.WebControls.Panel danger, Label dangertxt)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection sqlcon = new SqlConnection(con);

            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }

            if(ArtadoSql.Select("Name", "APIs", "Name", name, con, "string") != null)
            {
                sharepanel.Visible = true;
                danger.Visible = true;
                dangertxt.Text = "Bu ad daha önce alınmış!";
            }
            else
            {
                //Create API Key
                string key = name.Replace(" ", "-") + Guid.NewGuid().ToString().Replace("-", "");

                string istek = "insert into artadoco_admin.APIs(Name, DevID, DevName, Type, URL, APIKey) values (@Name, @DevID, @DevName, @Type, @URL, @APIKey)";
                SqlCommand cmd = new SqlCommand(istek, sqlcon);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@DevName", devname);
                cmd.Parameters.AddWithValue("@DevID", devid);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@URL", url);
                cmd.Parameters.AddWithValue("@APIKey", key);
                cmd.ExecuteNonQuery();
            }
        }
    }
}