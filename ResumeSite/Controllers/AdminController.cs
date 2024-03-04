#region using
using Microsoft.AspNetCore.Mvc;
using resume.Domain.Entities;
using resume.Domain.Entities.Person;
#endregion
namespace Resume.presenation.Controllers
{
    public class AdminController : Controller
	{
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Person person)
        {
            if (person.UserName == "Alireza" && person.Password == "138367070")
            {
                return View("Index");

            }
            else
            {
                return View("LoginError");
            }

        }

    }
}
