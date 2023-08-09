using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtadoDevs.Panel
{
    public partial class Panel : System.Web.UI.Page
    {
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();
        HttpCookie id = HttpContext.Current.Request.Cookies["id"];
        SqlConnection connect = new SqlConnection();

        string name;

        //username
        static string user;

        //Mail
        static string mail;

        //Profile Pic
        string image;

        //Code for Auth
        static int code;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (id == null || id.Value == null || ArtadoSql.Select("PassID", "Devs", "PassID", EncryptClass.Decrypt(id.Value), con, "int") == string.Empty)
            {
                id.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(id);
                Session.Abandon();

                Response.Redirect("/");
            }
            else
            {
                try
                {
                    connect.ConnectionString = con;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    string url = Request.RawUrl;
                    string product;
                    int edit = url.IndexOf("/edit/");
                    int vercon = url.IndexOf("/versions/");
                    // int details = url.IndexOf("/details/");

                    SqlCommand control = new SqlCommand("select Name from artadoco_admin.Devs where PassID='" + EncryptClass.Decrypt(id.Value.Replace("'", "\'").Replace('"', '\"')) + "'", connect);
                    name = (string)control.ExecuteScalar();

                    if (name != null)
                    {
                        if (edit >= 1)
                        {
                            try
                            {
                                product = RouteData.Values["product"].ToString();
                                string type = GetProduct.Info("Type", product, EncryptClass.Decrypt(id.Value));

                                string productname;
                                string desc;
                                string genre;
                                string status;

                                switch (type)
                                {
                                    case "App":
                                        Apps_Data.Visible = false;
                                        appstext.Visible = false;
                                        Button1.Visible = false;
                                        main.Visible = false;
                                        apps.Visible = true;
                                        apis.Visible = false;
                                        showcase.Visible = false;
                                        games.Visible = false;
                                        settings.Visible = false;

                                        share_app.Visible = true;
                                        share_game.Visible = false;
                                        danger_panel.Visible = false;
                                        appupload.Visible = false;
                                        nomore.Visible = false;

                                        Soon.Visible = false;
                                        ver_con.Visible = false;
                                        Workshop.Visible = false;

                                        Button11.Attributes.Add("style", "margin-top: 5px !important");
                                        Button12.Attributes.Add("style",
                                            "background-color: transparent; margin-top: 5px !important");

                                        productname = GetProduct.Info("Name", product,
                                            EncryptClass.Decrypt(id.Value));
                                        desc = GetProduct.Info("Description", product,
                                            EncryptClass.Decrypt(id.Value));
                                        genre = GetProduct.Info("Genre", product,
                                            EncryptClass.Decrypt(id.Value));
                                        status = GetProduct.Info("DevStatus", product,
                                            EncryptClass.Decrypt(id.Value));

                                        Label5.Visible = false;
                                        Label0.Visible = true;
                                        Label7.Visible = false;
                                        Label70.Visible = true;

                                        TextBox1.Attributes.Add("Value", productname);
                                        TextArea1.InnerText = desc;
                                        Genres.SelectedValue = genre;
                                        DevStatus.SelectedValue = status;
                                        break;
                                    case "Game":
                                        Game_Data.Visible = false;
                                        gamestext.Visible = false;
                                        Button2.Visible = false;

                                        share_app.Visible = false;
                                        share_game.Visible = true;
                                        main.Visible = false;
                                        apps.Visible = false;
                                        showcase.Visible = false;
                                        nomoregame.Visible = false;
                                        apis.Visible = false;
                                        settings.Visible = false;

                                        danger_panel.Visible = false;
                                        gamedanger_panel.Visible = false;
                                        project_upload.Visible = false;
                                        nomore.Visible = false;
                                        Soon.Visible = false;
                                        ver_con.Visible = false;
                                        Workshop.Visible = false;

                                        Button11.Attributes.Add("style", "margin-top: 5px !important");
                                        Button12.Attributes.Add("style",
                                            "background-color: transparent; margin-top: 5px !important");

                                        productname = GetProduct.Info("Name", product,
                                            EncryptClass.Decrypt(id.Value));
                                        desc = GetProduct.Info("Description", product,
                                            EncryptClass.Decrypt(id.Value));
                                        genre = GetProduct.Info("Genre", product,
                                            EncryptClass.Decrypt(id.Value));
                                        status = GetProduct.Info("DevStatus", product,
                                            EncryptClass.Decrypt(id.Value));

                                        Label28.Visible = false;
                                        Label55.Visible = true;
                                        Label30.Visible = false;
                                        Label56.Visible = true;

                                        TextBox3.Attributes.Add("Value", productname);
                                        TextArea2.InnerText = desc;
                                        DropDownList1.SelectedValue = genre;
                                        DropDownList2.SelectedValue = status;
                                        break;
                                    case "Workshop":
                                        share_app.Visible = false;
                                        share_game.Visible = false;
                                        main.Visible = false;
                                        apps.Visible = false;
                                        showcase.Visible = false;
                                        nomoregame.Visible = false;
                                        apis.Visible = false;
                                        settings.Visible = false;
                                        games.Visible = false;
                                        p_upload.Visible = false;

                                        danger_panel.Visible = false;
                                        gamedanger_panel.Visible = false;
                                        project_upload.Visible = false;
                                        nomore.Visible = false;
                                        Soon.Visible = false;
                                        ver_con.Visible = false;
                                        Workshop.Visible = true;

                                        workshop_projects.Visible = false;
                                        Workshop_Text.Visible = false;
                                        Button15.Visible = false;

                                        shareproject.Visible = true;

                                        Label74.Visible = false;
                                        Label76.Visible = false;

                                        Panel3.Visible = false;

                                        Button16.Attributes.Add("style", "margin-top: 5px !important");
                                        Button17.Attributes.Add("style",
                                            "background-color: transparent; margin-top: 5px !important");

                                        productname = GetProduct.Info("Name", product,
                                            EncryptClass.Decrypt(id.Value));
                                        desc = GetProduct.Info("Description", product,
                                            EncryptClass.Decrypt(id.Value));
                                        genre = GetProduct.Info("Genre", product,
                                            EncryptClass.Decrypt(id.Value));

                                        Label28.Visible = false;
                                        Label55.Visible = true;
                                        Label30.Visible = false;
                                        Label56.Visible = true;

                                        TextBox8.Attributes.Add("Value", productname);
                                        TextArea3.InnerText = desc;
                                        DropDownList3.SelectedValue = genre;
                                        break;
                                    default:
                                        Response.Redirect("/devs/panel");
                                        break;
                                }
                            }
                            catch
                            {

                                Response.Redirect("/devs/panel");
                            }
                        }
                        else if (vercon >= 1)
                        {
                            if (!IsPostBack)
                            {
                                share_app.Visible = false;
                                share_game.Visible = false;
                                main.Visible = false;
                                apps.Visible = false;
                                games.Visible = false;
                                showcase.Visible = false;
                                nomoregame.Visible = false;
                                apis.Visible = false;
                                settings.Visible = false;
                                Workshop.Visible = false;

                                danger_panel.Visible = false;
                                gamedanger_panel.Visible = false;
                                project_upload.Visible = false;
                                nomore.Visible = false;
                                Soon.Visible = false;
                                ver_con.Visible = true;
                                nomore_ver.Visible = false;

                                Button11.Attributes.Add("style", "background-color: transparent; margin-top: 5px !important");
                                Button12.Attributes.Add("style", "margin-top: 5px !important");
                                Button13.Attributes.Add("style", "background-color: transparent; margin-top: 5px !important");
                                Button14.Attributes.Add("style", "margin-top: 5px !important");
                                Button16.Attributes.Add("style", "background-color: transparent; margin-top: 5px !important");
                                Button17.Attributes.Add("style", "margin-top: 5px !important");

                                product = RouteData.Values["product"].ToString();

                                GetProduct.Versions(versionsdata, product);

                                for (int i = 0; i < versionsdata.Items.Count; i++)
                                {
                                    Image img = versionsdata.Items[i].FindControl("ver_image") as Image;
                                    string img_path = ArtadoSql.Select("Logo", "Products", "ID", product, con, "string");
                                    img.ImageUrl = "/Upload/Images/" + img_path;

                                    Label gamename = versionsdata.Items[i].FindControl("Label2") as Label;
                                    string game = ArtadoSql.Select("Name", "Products", "ID", product, con, "string");
                                    gamename.Text = game;
                                }
                            }
                        }
                        else
                        {
                            if (url == "/devs/panel")
                            {
                                main.Visible = true;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = true;
                                games.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                Soon.Visible = false;

                                GetProduct.Products(Projects, "all", EncryptClass.Decrypt(id.Value));
                            }
                            else if (url == "/devs/panel/apps")
                            {
                                main.Visible = false;
                                apps.Visible = true;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomore.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                danger_panel.Visible = false;

                                Soon.Visible = false;

                                GetProduct.Products(Apps_Data, "App", EncryptClass.Decrypt(id.Value));
                            }
                            else if (url == "/devs/panel/games")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = true;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;

                                Soon.Visible = false;

                                GetProduct.Products(Game_Data, "Game", EncryptClass.Decrypt(id.Value));
                            }
                            else if (url == "/devs/panel/sites")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;

                                Soon.Visible = true;
                            }
                            else if (url == "/devs/panel/workshop")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = true;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;
                                shareproject.Visible = false;

                                Soon.Visible = false;

                                GetProduct.Products(workshop_projects, "Workshop", EncryptClass.Decrypt(id.Value));
                            }
                            else if (url == "/devs/panel/api")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = true;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                api_create.Visible = false;
                                APIdanger.Visible = false;

                                Soon.Visible = false;

                                GetProduct.APIs(API_Data, "all", EncryptClass.Decrypt(id.Value));
                            }
                            else if (url == "/devs/panel/events")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;

                                Soon.Visible = true;
                            }
                            else if (url == "/devs/panel/collections")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;

                                Soon.Visible = true;
                            }
                            else if (url == "/devs/panel/team")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                settings.Visible = false;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                nomoregame.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;

                                Soon.Visible = true;
                            }
                            else if (url == "/devs/panel/settings")
                            {
                                main.Visible = false;
                                apps.Visible = false;
                                apis.Visible = false;
                                showcase.Visible = false;
                                games.Visible = false;
                                nomoregame.Visible = false;
                                settings.Visible = true;
                                ver_con.Visible = false;
                                Workshop.Visible = false;

                                share_app.Visible = false;
                                share_game.Visible = false;
                                gamedanger_panel.Visible = false;
                                Panel1.Visible = false;
                                valid.Visible = false;
                                warn_v.Visible = false;

                                Soon.Visible = false;

                                //Get the account credits
                                att.Visible = false;
                                danger_panel.Visible = false;

                                if (connect.State == ConnectionState.Closed)
                                {
                                    connect.Open();
                                }
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = connect;

                                //Get the profile pic
                                string query = "SELECT Logo FROM Devs where PassID='" + EncryptClass.Decrypt(id.Value.Replace('"', '\"')) + "' ";
                                cmd.CommandText = query;
                                image = (string)cmd.ExecuteScalar();
                                pfp.ImageUrl = "/Upload/profiles/" + image;

                                //Get the mail
                                query = "SELECT Mail FROM Devs where PassID='" + EncryptClass.Decrypt(id.Value.Replace('"', '\"')) + "' ";
                                cmd.CommandText = query;
                                mail = (string)cmd.ExecuteScalar();
                                email.Attributes.Add("Value", mail.Trim());

                                //Get the username
                                query = "SELECT Name FROM Devs where PassID='" + EncryptClass.Decrypt(id.Value.Replace('"', '\"')) + "' ";
                                cmd.CommandText = query;
                                user = (string)cmd.ExecuteScalar();
                                username.Attributes.Add("Value", user.Trim());

                                connect.Close();
                            }
                            else
                            {
                                Response.Redirect("/devs/panel");
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
                }
                catch (Exception hata)
                {
                    Response.Write(hata);
                }
            }

            SqlConnection.ClearAllPools();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string product = RouteData.Values["product"].ToString();

            Response.Redirect("/devs/panel/edit/" + product);
        }

        protected void Version_Click(object sender, EventArgs e)
        {
            string product = RouteData.Values["product"].ToString();

            Response.Redirect("/devs/panel/versions/" + product);
        }

        protected void ShareApps(object sender, EventArgs e)
        {
            Repeater count = new Repeater();
            GetProduct.Products(count, "App", EncryptClass.Decrypt(id.Value));
            if (count.Items.Count < 5)
            {
                Apps_Data.Visible = false;
                appstext.Visible = false;
                Button1.Visible = false;

                share_app.Visible = true;
                share_game.Visible = false;

                Label5.Visible = true;
                Label0.Visible = false;
                Label7.Visible = true;
                Label70.Visible = false;

                Button11.Visible = false;
                Button12.Visible = false;
            }
            else
            {
                nomore.Visible = true;
            }
        }

        protected void ShareGames(object sender, EventArgs e)
        {
            Repeater count = new Repeater();
            GetProduct.Products(count, "Game", EncryptClass.Decrypt(id.Value));
            if (count.Items.Count < 5)
            {
                Game_Data.Visible = false;
                gamestext.Visible = false;
                Button2.Visible = false;

                share_app.Visible = false;
                share_game.Visible = true;

                Label55.Visible = false;
                Label56.Visible = false;

                Button13.Visible = false;
                Button14.Visible = false;
            }
            else
            {
                nomoregame.Visible = true;
            }
        }

        protected void ShareWorkshop(object sender, EventArgs e)
        {
            workshop_projects.Visible = false;
            Workshop_Text.Visible = false;
            Button15.Visible = false;

            shareproject.Visible = true;

            Label74.Visible = false;
            Label76.Visible = false;

            Button16.Visible = false;
            Button17.Visible = false;

            Panel3.Visible = false;
        }

        protected void CreateAPI(object sender, EventArgs e)
        {
            API_Data.Visible = false;
            API_text.Visible = false;
            Button8.Visible = false;

            share_app.Visible = false;
            share_game.Visible = false;
            api_create.Visible = true;

            Label64.Visible = true;
            Label65.Visible = false;
            Label66.Visible = true;
            Label67.Visible = false;
        }

        #region CreateVersion
        protected void CreateVersion(object sender, EventArgs e)
        {
            string product = RouteData.Values["product"].ToString();
            string type = ArtadoSql.Select("Type", "Products", "ID", product, con, "string");

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = con;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            string query = "SELECT Status FROM Versions where ProductID='" + product + "' order by ID desc ";
            cmd.CommandText = query;
            var status = (string)cmd.ExecuteScalar();
            connection.Close();

            if (status == "Waiting")
            {
                nomore_ver.Visible = true;
            }
            else
            {
                switch (type)
                {
                    case "App":
                        Apps_Data.Visible = false;
                        appstext.Visible = false;
                        Button1.Visible = false;
                        main.Visible = false;
                        apps.Visible = true;
                        apis.Visible = false;
                        showcase.Visible = false;
                        games.Visible = false;
                        settings.Visible = false;

                        share_app.Visible = true;
                        app_details.Visible = false;
                        share_game.Visible = false;
                        danger_panel.Visible = false;
                        appupload.Visible = true;
                        nomore.Visible = false;

                        Soon.Visible = false;
                        ver_con.Visible = false;
                        break;
                    case "Game":
                        Game_Data.Visible = false;
                        gamestext.Visible = false;
                        Button2.Visible = false;

                        share_app.Visible = false;
                        share_game.Visible = true;
                        main.Visible = false;
                        games.Visible = true;
                        apps.Visible = false;
                        showcase.Visible = false;
                        nomoregame.Visible = false;
                        apis.Visible = false;
                        settings.Visible = false;

                        danger_panel.Visible = false;
                        gamedanger_panel.Visible = false;
                        project_upload.Visible = true;
                        game_details.Visible = false;
                        nomore.Visible = false;
                        Soon.Visible = false;
                        ver_con.Visible = false;
                        break;
                    default:
                        Workshop.Visible = true;
                        workshop_projects.Visible = false;
                        Workshop_Text.Visible = false;
                        Button15.Visible = false;
                        project_details.Visible = false;

                        shareproject.Visible = true;

                        Label74.Visible = false;
                        Label76.Visible = false;

                        Button16.Visible = true;
                        Button17.Visible = true;

                        Panel3.Visible = false;
                        danger_panel.Visible = false;
                        gamedanger_panel.Visible = false;
                        p_upload.Visible = true;
                        game_details.Visible = false;
                        nomore.Visible = false;
                        Soon.Visible = false;
                        ver_con.Visible = false;
                        break;
                }
            }
        }
        #endregion

        #region AppSave
        protected void AppSave(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), DevStatus.SelectedValue, TextBox1.Text, TextArea1.InnerText, "App", Genres.SelectedValue, TextBox6.Text, AppLogoUp, FileUpload8, FileUpload1, TextBox2.Text, FileUpload2, FileUpload3, FileUpload4, FileUpload7, FileUpload5, FileUpload6, share_app, danger_panel, Uyarı);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload2.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload2, "win", danger_panel, Uyarı, "WinFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload3.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload3, "linux", danger_panel, Uyarı, "LinuxFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload4.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload4, "mac", danger_panel, Uyarı, "MacFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload7.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload7, "android", danger_panel, Uyarı, "AndroidFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload5.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload5, "bsd", danger_panel, Uyarı, "BSDFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload6.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload6, "haiku", danger_panel, Uyarı, "HaikuFolder", Int32.Parse(product), TextBox6.Text);
                }

                Apps_Data.Visible = false;
                appstext.Visible = false;
                Button1.Visible = false;
                main.Visible = false;
                apps.Visible = true;
                apis.Visible = false;
                showcase.Visible = false;
                games.Visible = false;
                settings.Visible = false;

                share_app.Visible = true;
                app_details.Visible = false;
                share_game.Visible = false;
                danger_panel.Visible = false;
                appupload.Visible = true;
                nomore.Visible = false;

                Soon.Visible = false;
            }
            else
            {
                Repeater count = new Repeater();
                GetProduct.Products(count, "App", EncryptClass.Decrypt(id.Value));
                if (count.Items.Count < 5)
                {
                    Interactions.Share("Saved", name, EncryptClass.Decrypt(id.Value), DevStatus.SelectedValue, TextBox1.Text, TextArea1.InnerText, "App", Genres.SelectedValue, TextBox6.Text, AppLogoUp, FileUpload8, FileUpload1, TextBox2.Text, FileUpload2, FileUpload3, FileUpload4, FileUpload7, FileUpload5, FileUpload6, share_app, danger_panel, Uyarı);
                    main.Visible = false;
                    apps.Visible = true;
                    showcase.Visible = false;
                    games.Visible = false;
                    nomore.Visible = false;
                    settings.Visible = false;

                    share_app.Visible = false;
                    share_game.Visible = false;
                    danger_panel.Visible = false;

                    Soon.Visible = false;

                    GetProduct.Products(Apps_Data, "App", EncryptClass.Decrypt(id.Value));
                }
                else
                {
                    nomore.Visible = true;
                }
            }
        }
        #endregion

        #region AppPublish
        protected void AppPublish(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), DevStatus.SelectedValue, TextBox1.Text, TextArea1.InnerText, "App", Genres.SelectedValue, TextBox6.Text, AppLogoUp, FileUpload8, FileUpload1, TextBox2.Text, FileUpload2, FileUpload3, FileUpload4, FileUpload7, FileUpload5, FileUpload6, share_app, danger_panel, Uyarı);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload2.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload2, "win", danger_panel, Uyarı, "WinFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload3.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload3, "linux", danger_panel, Uyarı, "LinuxFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload4.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload4, "mac", danger_panel, Uyarı, "MacFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload7.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload7, "android", danger_panel, Uyarı, "AndroidFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload5.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload5, "bsd", danger_panel, Uyarı, "BSDFolder", Int32.Parse(product), TextBox6.Text);
                }
                if (FileUpload6.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload6, "haiku", danger_panel, Uyarı, "HaikuFolder", Int32.Parse(product), TextBox6.Text);
                }

                Apps_Data.Visible = false;
                appstext.Visible = false;
                Button1.Visible = false;
                main.Visible = false;
                apps.Visible = true;
                apis.Visible = false;
                showcase.Visible = false;
                games.Visible = false;
                settings.Visible = false;

                share_app.Visible = true;
                app_details.Visible = false;
                share_game.Visible = false;
                danger_panel.Visible = false;
                appupload.Visible = true;
                nomore.Visible = false;

                Soon.Visible = false;
            }
            else
            {
                Repeater count = new Repeater();
                GetProduct.Products(count, "App", EncryptClass.Decrypt(id.Value));
                if (count.Items.Count < 5)
                {
                    Interactions.Share("Waiting", name, EncryptClass.Decrypt(id.Value), DevStatus.SelectedValue, TextBox1.Text, TextArea1.InnerText, "App", Genres.SelectedValue, TextBox6.Text, AppLogoUp, FileUpload8, FileUpload1, TextBox2.Text, FileUpload2, FileUpload3, FileUpload4, FileUpload7, FileUpload5, FileUpload6, share_app, danger_panel, Uyarı);
                    main.Visible = false;
                    apps.Visible = true;
                    showcase.Visible = false;
                    games.Visible = false;
                    nomore.Visible = false;
                    settings.Visible = false;

                    share_app.Visible = false;
                    share_game.Visible = false;
                    danger_panel.Visible = false;

                    Soon.Visible = false;

                    GetProduct.Products(Apps_Data, "App", EncryptClass.Decrypt(id.Value));
                }
                else
                {
                    nomore.Visible = true;
                }
            }
        }
        #endregion

        #region GameSave
        protected void GameSave(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), DropDownList2.SelectedValue, TextBox3.Text, TextArea2.InnerText, "Game", DropDownList1.SelectedValue, TextBox7.Text, FileUpload9, FileUpload10, FileUpload11, TextBox4.Text, FileUpload12, FileUpload13, FileUpload14, FileUpload15, FileUpload16, FileUpload17, share_game, gamedanger_panel, GameUyarı);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload12.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload12, "win", gamedanger_panel, GameUyarı, "WinFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload13.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload13, "linux", gamedanger_panel, GameUyarı, "LinuxFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload14.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload14, "mac", gamedanger_panel, GameUyarı, "MacFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload17.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload17, "android", gamedanger_panel, GameUyarı, "AndroidFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload15.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload15, "bsd", gamedanger_panel, GameUyarı, "BSDFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload16.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload16, "haiku", gamedanger_panel, GameUyarı, "HaikuFolder", Int32.Parse(product), TextBox7.Text);
                }

                Game_Data.Visible = false;
                gamestext.Visible = false;
                Button2.Visible = false;

                share_app.Visible = false;
                share_game.Visible = true;
                main.Visible = false;
                games.Visible = true;
                apps.Visible = false;
                showcase.Visible = false;
                nomoregame.Visible = false;
                apis.Visible = false;
                settings.Visible = false;

                danger_panel.Visible = false;
                gamedanger_panel.Visible = false;
                project_upload.Visible = true;
                game_details.Visible = false;
                nomore.Visible = false;
                Soon.Visible = false;
                ver_con.Visible = false;
            }
            else
            {
                Repeater count = new Repeater();
                GetProduct.Products(count, "Game", EncryptClass.Decrypt(id.Value));
                if (count.Items.Count < 5)
                {
                    Interactions.Share("Saved", name, EncryptClass.Decrypt(id.Value), DropDownList2.SelectedValue, TextBox3.Text, TextArea2.InnerText, "Game", DropDownList1.SelectedValue, TextBox7.Text, FileUpload9, FileUpload10, FileUpload11, TextBox4.Text, FileUpload12, FileUpload13, FileUpload14, FileUpload15, FileUpload16, FileUpload17, share_game, gamedanger_panel, GameUyarı);
                    main.Visible = false;
                    apps.Visible = false;
                    showcase.Visible = false;
                    games.Visible = true;
                    nomoregame.Visible = false;
                    settings.Visible = false;

                    share_app.Visible = false;
                    share_game.Visible = false;
                    gamedanger_panel.Visible = false;

                    Soon.Visible = false;

                    GetProduct.Products(Game_Data, "Game", EncryptClass.Decrypt(id.Value));
                }
                else
                {
                    nomoregame.Visible = true;
                }
            }
        }
        #endregion

        #region GamePublish
        protected void GamePublish(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), DropDownList2.SelectedValue, TextBox3.Text, TextArea2.InnerText, "Game", DropDownList1.SelectedValue, TextBox7.Text, FileUpload9, FileUpload10, FileUpload11, TextBox4.Text, FileUpload12, FileUpload13, FileUpload14, FileUpload15, FileUpload16, FileUpload17, share_game, gamedanger_panel, GameUyarı);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload12.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload12, "win", gamedanger_panel, GameUyarı, "WinFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload13.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload13, "linux", gamedanger_panel, GameUyarı, "LinuxFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload14.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload14, "mac", gamedanger_panel, GameUyarı, "MacFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload17.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload17, "android", gamedanger_panel, GameUyarı, "AndroidFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload15.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload15, "bsd", gamedanger_panel, GameUyarı, "BSDFolder", Int32.Parse(product), TextBox7.Text);
                }
                if (FileUpload16.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload16, "haiku", gamedanger_panel, GameUyarı, "HaikuFolder", Int32.Parse(product), TextBox7.Text);
                }

                Game_Data.Visible = false;
                gamestext.Visible = false;
                Button2.Visible = false;

                share_app.Visible = false;
                share_game.Visible = true;
                main.Visible = false;
                games.Visible = true;
                apps.Visible = false;
                showcase.Visible = false;
                nomoregame.Visible = false;
                apis.Visible = false;
                settings.Visible = false;

                danger_panel.Visible = false;
                gamedanger_panel.Visible = false;
                project_upload.Visible = true;
                game_details.Visible = false;
                nomore.Visible = false;
                Soon.Visible = false;
                ver_con.Visible = false;
            }
            else
            {
                Repeater count = new Repeater();
                GetProduct.Products(count, "App", EncryptClass.Decrypt(id.Value));
                if (count.Items.Count < 5)
                {
                    Interactions.Share("Waiting", name, EncryptClass.Decrypt(id.Value), DropDownList2.SelectedValue, TextBox3.Text, TextArea2.InnerText, "Game", DropDownList1.SelectedValue, TextBox7.Text, FileUpload9, FileUpload10, FileUpload11, TextBox4.Text, FileUpload12, FileUpload13, FileUpload14, FileUpload15, FileUpload16, FileUpload17, share_game, gamedanger_panel, GameUyarı);
                }
                else
                {
                    nomore.Visible = true;
                }
            }
        }
        #endregion
        #region WorkshopSave
        protected void WorkshopSave(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), "Release", TextBox8.Text, TextArea3.InnerText, "Workshop", DropDownList3.SelectedValue, TextBox10.Text, FileUpload19, FileUpload20, FileUpload21, TextBox9.Text, FileUpload22, null, null, null, null, null, shareproject, Panel3, Label77);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload22.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload22, "win", Panel3, Label77, "WinFolder", Int32.Parse(product), TextBox10.Text);
                }

                Apps_Data.Visible = false;
                appstext.Visible = false;
                Button1.Visible = false;
                main.Visible = false;
                apps.Visible = true;
                apis.Visible = false;
                showcase.Visible = false;
                games.Visible = false;
                settings.Visible = false;

                share_app.Visible = true;
                app_details.Visible = false;
                share_game.Visible = false;
                danger_panel.Visible = false;
                appupload.Visible = true;
                nomore.Visible = false;

                Soon.Visible = false;
            }
            else
            {
                Interactions.Share("Saved", name, EncryptClass.Decrypt(id.Value), "Release", TextBox8.Text, TextArea3.InnerText, "Workshop", DropDownList3.SelectedValue, TextBox10.Text, FileUpload19, FileUpload20, FileUpload21, TextBox9.Text, FileUpload22, null, null, null, null, null, shareproject, Panel3, Label77);
                main.Visible = false;
                apps.Visible = true;
                showcase.Visible = false;
                games.Visible = false;
                nomore.Visible = false;
                settings.Visible = false;

                share_app.Visible = false;
                share_game.Visible = false;
                danger_panel.Visible = false;

                Soon.Visible = false;

                GetProduct.Products(Apps_Data, "App", EncryptClass.Decrypt(id.Value));
            }
        }
        #endregion
        protected void WorkshopPublish(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            int edit = url.IndexOf("/edit/");
            int vercon = url.IndexOf("/versions/");

            if (edit >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                Interactions.Update(product, "Update", name, EncryptClass.Decrypt(id.Value), "Release", TextBox8.Text, TextArea3.InnerText, "Workshop", DropDownList3.SelectedValue, TextBox10.Text, FileUpload19, FileUpload20, FileUpload21, TextBox9.Text, FileUpload22, null, null, null, null, null, shareproject, Panel3, Label77);
            }
            else if (vercon >= 1)
            {
                string product = RouteData.Values["product"].ToString();
                if (FileUpload22.HasFile)
                {
                    Interactions.UploadProduct(true, FileUpload22, "win", Panel3, Label77, "WinFolder", Int32.Parse(product), TextBox10.Text);
                }

                main.Visible = false;
                apps.Visible = false;
                apis.Visible = false;
                showcase.Visible = false;
                games.Visible = false;
                nomoregame.Visible = false;
                settings.Visible = false;
                ver_con.Visible = false;
                Workshop.Visible = true;

                share_app.Visible = false;
                share_game.Visible = false;
                gamedanger_panel.Visible = false;
                shareproject.Visible = false;

                Soon.Visible = false;
            }
            else
            {
                Interactions.Share("Waiting", name, EncryptClass.Decrypt(id.Value), "Release", TextBox8.Text, TextArea3.InnerText, "Workshop", DropDownList3.SelectedValue, TextBox10.Text, FileUpload19, FileUpload20, FileUpload21, TextBox9.Text, FileUpload22, null, null, null, null, null, shareproject, Panel3, Label77);
                main.Visible = false;
                apps.Visible = false;
                apis.Visible = false;
                showcase.Visible = false;
                games.Visible = false;
                nomoregame.Visible = false;
                settings.Visible = false;
                ver_con.Visible = false;
                Workshop.Visible = true;

                share_app.Visible = false;
                share_game.Visible = false;
                gamedanger_panel.Visible = false;
                shareproject.Visible = false;

                Soon.Visible = false;

                GetProduct.Products(Apps_Data, "App", EncryptClass.Decrypt(id.Value));
            }
        }

        protected void APIPublish(object sender, EventArgs e)
        {
            Interactions.CreateAPI(TextBox5.Text, APIurl.Text, name, EncryptClass.Decrypt(id.Value), APItype.SelectedValue, api_create, APIdanger, Label68);
        }

        protected void AccUpdate(object sender, EventArgs e)
        {
            //Profile Picture
            if (upload.HasFile)
            {
                FileInfo fileinfo = new FileInfo(upload.FileName);
                string filename = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
                filename += Guid.NewGuid().ToString().Replace("-", "") + fileinfo.Extension;
                upload.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Upload/profiles/" + filename));

                //deletes old profile pic
                if (image != "image.png")
                {
                    string path = Server.MapPath("/Upload/profiles/" + image);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//checks if old profile pic exist or not  
                    {
                        file.Delete();
                    }
                }

                ArtadoSql.Update("Logo", filename, "Devs", "PassID", EncryptClass.Decrypt(id.Value), con);
            }

            //Email
            if (email.Text != mail)
            {
                if (ArtadoSql.Select("Mail", "Devs", "Mail", email.Text, con, "string") == null)
                {
                    //Creates confirmation code
                    Random rnm = new Random();

                    code = rnm.Next(100000, 999999);

                    //Gets the browser and IP info for e-mail confirmation
                    string browser = Request.Browser.Browser;
                    string ip = Request.UserHostAddress;

                    MailSend.Send(true, email.Text, Panel1, browser, ip, code);
                    valid.Visible = true;
                    edit.Visible = false;
                }
                else
                {
                    Panel1.Visible = true;
                }
            }

            //Username
            if (username.Text != user)
            {
                if (ArtadoSql.Select("Name", "Devs", "Name", username.Text, con, "string") == null)
                {
                    ArtadoSql.Update("Name", username.Text, "Devs", "PassID", EncryptClass.Decrypt(id.Value), con);
                }
                else
                {
                    Panel1.Visible = true;
                }
            }

            //Password
            if (password.Text != string.Empty)
            {
                string salt = ArtadoSql.Select("Salt", "Devs", "PassID", EncryptClass.Decrypt(id.Value), con, "string");
                string pwdHashed = SecurityHelper.HashPassword(password.Text, salt, 10101, 70);

                ArtadoSql.Update("Password", pwdHashed, "Devs", "PassID", EncryptClass.Decrypt(id.Value), con);
            }

            if (bio.Value != string.Empty)
            {
                ArtadoSql.Update("Bio", bio.Value, "Devs", "PassID", EncryptClass.Decrypt(id.Value), con);
            }
        }

        protected void Resend(object sender, EventArgs e)
        {
            //Creates confirmation code
            Random rnm = new Random();

            code = rnm.Next(100000, 999999);

            //Gets the browser and IP info for e-mail confirmation
            string browser = Request.Browser.Browser;
            string ip = Request.UserHostAddress;

            MailSend.Send(true, email.Text, Panel1, browser, ip, code);
            valid.Visible = true;
            edit.Visible = false;
        }

        protected void CodeAccept(object sender, EventArgs e)
        {
            if (codebar.Text == code.ToString())
            {
                ArtadoSql.Update("Mail", email.Text, "Devs", "PassID", EncryptClass.Decrypt(id.Value), con);
                valid.Visible = false;
                edit.Visible = true;
            }
            else
            {
                warn_v.Visible = true;
            }
        }

        protected void More_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://discord.gg/WXCsr8zTN6");
        }
        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }
    }
}