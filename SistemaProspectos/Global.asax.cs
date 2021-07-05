using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SistemaProspectos
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SetRoutes();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError() as HttpException;
            if(error != null)
            {
                var statusCode = error.GetHttpCode();
                if(statusCode == 404)
                {
                    Server.ClearError();
                    Response.RedirectToRoute("NotFound");
                }
                else if(statusCode == 500)
                {
                    Server.ClearError();
                    Response.RedirectToRoute("Error");
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void SetRoutes()
        {
            //SITE
            RouteTable.Routes.MapPageRoute("Default", "prospectos/", "~/views/Default.aspx");
            RouteTable.Routes.MapPageRoute("Agregar", "agregar-prospecto/", "~/views/AgregarProspecto.aspx");
            RouteTable.Routes.MapPageRoute("Evaluar", "evaluar-prospecto/", "~/views/EvaluacionProspecto.aspx");

            //ERROR PAGES
            RouteTable.Routes.MapPageRoute("Error", "error/", "~/views/error/Error.aspx");
            RouteTable.Routes.MapPageRoute("NotFound", "not-found/", "~/views/error/NotFound.aspx");
        }
    }
}