﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();
            
            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                HttpException exec = exc as HttpException;
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.

                if (exec.GetHttpCode() == 404)
                {
                    Response.Redirect("Error/NotFound");
                    return;
                }

                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("NotFound.cshtml");
            }

            //// For other kinds of errors give the user some information
            //// but stay on the default page
            //Response.Write("<h2>Global Page Error</h2>\n");
            //Response.Write(
            //    "<p>" + exc.Message + "</p>\n");
            //Response.Write("Return to the <a href='Default.aspx'>" +
            //    "Default Page</a>\n");

            //// Log the exception and notify system operators
            //ExceptionUtility.LogException(exc, "DefaultPage");
            //ExceptionUtility.NotifySystemOps(exc);

            // Clear the error from the server
            Server.ClearError();
        }

    }
}
