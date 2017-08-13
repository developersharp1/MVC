using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        List<CheckModel> list1 = new List<CheckModel>
            {
                 new CheckModel{Id = 1, Name = "Aquafina", Checked = false, ImageUrl = "../../Images/nature0.jpg"},
                 new CheckModel{Id = 2, Name = "Mulshi Springs", Checked = false, ImageUrl = "../../Images/nature1.jpg"},
                 new CheckModel{Id = 3, Name = "Alfa Blue", Checked = false, ImageUrl = "../../Images/nature2.jpg"},
                 new CheckModel{Id = 4, Name = "Atlas Premium", Checked = false, ImageUrl = "../../Images/nature3.jpg"},
                    new CheckModel{Id = 1, Name = "Aquafina", Checked = false, ImageUrl = "../../Images/nature4.jpg"},
                 new CheckModel{Id = 2, Name = "Mulshi Springs", Checked = false, ImageUrl = "../../Images/nature5.jpg"},
                 new CheckModel{Id = 3, Name = "Alfa Blue", Checked = false, ImageUrl = "../../Images/nature6.jpg"},
                 new CheckModel{Id = 4, Name = "Atlas Premium", Checked = false, ImageUrl = "../../Images/nature7.jpg"},
                    new CheckModel{Id = 1, Name = "Aquafina", Checked = false, ImageUrl = "../../Images/nature8.jpg"},
                 new CheckModel{Id = 2, Name = "Mulshi Springs", Checked = false, ImageUrl = "../../Images/nature9.jpg"},
                 new CheckModel{Id = 3, Name = "Alfa Blue", Checked = false, ImageUrl = "../../Images/nature10.jpg"},
                 new CheckModel{Id = 4, Name = "Atlas Premium", Checked = false, ImageUrl = "../../Images/nature11.jpg"},
                    new CheckModel{Id = 1, Name = "Aquafina", Checked = false, ImageUrl = "../../Images/nature12.jpg"},
                 new CheckModel{Id = 2, Name = "Mulshi Springs", Checked = false, ImageUrl = "../../Images/nature13.jpg"},
                 new CheckModel{Id = 3, Name = "Alfa Blue", Checked = false, ImageUrl = "../../Images/nature14.jpg"},
                 new CheckModel{Id = 4, Name = "Atlas Premium", Checked = false, ImageUrl = "../../Images/nature15.jpg"}
            };


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Form()
        {
            var list = list1.GroupBy(x => x.Id, (key, g) => new FormModel { QuestionNumber = 1, optionList = g.ToList() }).ToList();
            FormModel model = new FormModel();
            model = list[0];
            model.QuestionText = "Select any one";
            return View(model);
        }
       
        [HttpPost]
        public PartialViewResult _form(FormModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                int QuestionNumber = model.QuestionNumber + 1;
               
                var list = list1.GroupBy(x => x.Id, (key, g) => new FormModel { QuestionNumber = QuestionNumber, optionList = g.ToList() }).ToList();
                if (QuestionNumber >= list.Count)
                {
                    return PartialView("_QuizEnd");
                }
                model = new FormModel();
                model = list[QuestionNumber - 1];
                model.QuestionText = "Select any one 232";               
                return PartialView(model);
            }
            string OptionListStr = Request.Form["OptionListStr"];
            List<CheckModel> objList = new List<CheckModel>();
            objList = JsonConvert.DeserializeObject<List<CheckModel>>(OptionListStr);
            model.optionList = objList;
            return PartialView(model);
        }
    }
}