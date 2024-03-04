#region using
using Microsoft.AspNetCore.Mvc;
using resume.Application.DTO.Home_Index;
using resume.Application.Services;
#endregion


namespace Resume.presenation.Controllers
{
    public class HomeController : Controller
    {
        private readonly EducationService EducationContext;
		private readonly MySkillsService MySkillsContext;


        public HomeController(EducationService _EducationContext, MySkillsService _MySkillsContext)
        {
            EducationContext = _EducationContext;
            MySkillsContext = _MySkillsContext;
        }
        public  IActionResult Index()
        {
            //ViewBag.EducatinList = EducationContext.GetAll();
            //ViewBag.MySkillsList = MySkillsContext.GetAll();

            MyskillsandEducation myskills_Education_list = new()
            {
                myskillslist = MySkillsContext.GetAll(),
                educationslist = EducationContext.GetAll()

            };

			return View(myskills_Education_list);
        }
        public IActionResult Education()
        {
            var Educations = EducationContext.GetAll();

            return View(Educations);
        }
        public IActionResult MySkills()
        {
            var MySkillss = MySkillsContext.GetAll();
            return View(MySkillss);
        }
        public IActionResult Blog()
        {
            return View();
        }



    }
}