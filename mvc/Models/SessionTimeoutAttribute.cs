﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Models
{
    public class SessionTimeoutAttribute: ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpContext ctx = HttpContext.Current;
        //    if (HttpContext.Current.Session["ID"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/Home/Login");
        //        return;
        //    }
        //    base.OnActionExecuting(filterContext);
        //}

    }
}