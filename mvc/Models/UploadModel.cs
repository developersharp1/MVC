using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class UploadModel
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public HttpPostedFile file { get; set; }
    }
}