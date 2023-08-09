using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ArtadoDevs
{
    public class Global : System.Web.HttpApplication
    {
        void adres(RouteCollection url)
        {
            url.MapPageRoute("default", "Home", "~/default.aspx");
            url.MapPageRoute("submit", "Submit", "~/Submit.aspx");
            url.MapPageRoute("panel", "devs/panel", "~/Panel/Panel.aspx");
            url.MapPageRoute("apps", "devs/panel/apps", "~/Panel/Panel.aspx");
            url.MapPageRoute("games", "devs/panel/games", "~/Panel/Panel.aspx");
            url.MapPageRoute("sites", "devs/panel/sites", "~/Panel/Panel.aspx");
            url.MapPageRoute("apis", "devs/panel/api", "~/Panel/Panel.aspx");
            url.MapPageRoute("workshop", "devs/panel/workshop", "~/Panel/Panel.aspx");
            url.MapPageRoute("events", "devs/panel/events", "~/Panel/Panel.aspx");
            url.MapPageRoute("collect", "devs/panel/collections", "~/Panel/Panel.aspx");
            url.MapPageRoute("team", "devs/panel/team", "~/Panel/Panel.aspx");
            url.MapPageRoute("settings", "devs/panel/settings", "~/Panel/Panel.aspx");
            url.MapPageRoute("manage", "devs/panel/edit/{product}", "~/Panel/Panel.aspx");
            url.MapPageRoute("versions", "devs/panel/versions/{product}", "~/Panel/Panel.aspx");
            url.MapPageRoute("details", "devs/panel/details/{product}", "~/Panel/Panel.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            adres(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}