using Microsoft.AspNetCore.Mvc;
using resume.Application.Services;
using resume.Domain.Entities.Person;

namespace Resume.presenation.Controllers
{
    public class GameController : Controller
    {
        private readonly PersonService Context;
        public GameController(PersonService _Context)
        {
            Context = _Context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Game()
        {

            return View();
        }

        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Person person)
        {

            var persons=Context.Find(person);
            if (persons.Count==0){
                return View("RegisterError");
            }
            else{
                return View("Game");
            }


        }

        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Person person)
        {
            await Context.Create(person);
            
            return View(nameof(Game));
        }



    }
}
