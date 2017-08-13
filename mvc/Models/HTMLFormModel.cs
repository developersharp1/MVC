using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class HTMLFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MobileNo is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "EmailId is required")]        
        public string EmailId { get; set; }
    }
}