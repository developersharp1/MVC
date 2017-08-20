using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Models
{
    public class CustomErrorAttribute: HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            var tempData = new TempDataDictionary();
            tempData.Add("IsException", "true");            
            filterContext.Result = new ViewResult()
            {         
                TempData = tempData,       
                //ViewName = "Error",
                //ViewData = new ViewDataDictionary(model) ,                
            };
        }
    }
}