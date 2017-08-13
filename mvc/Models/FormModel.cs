using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class FormModel
    {
        public string QuestionText { get; set; }
        public int QuestionNumber { get; set; }

        public List<CheckModel> optionList { get; set; }
        //public int LastIndex { get; set; }

        [Required(ErrorMessage = "Please select a option")]
        public string UserAnswer { get; set; }
    }


    public class CheckModel
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        public bool Checked
        {
            get;
            set;
        }

        public string ImageUrl { get; set; }
    }
}