using Microsoft.AspNetCore.Mvc;
using resume.Application.Services;
using resume.Domain.Entities.Person;

namespace Resume.presenation.Controllers
{
    public class PersonController : Controller
    {
        readonly PersonService Service;
        public PersonController(PersonService _service)
        {
            Service = _service;
        }
        public async Task<IActionResult> Index()
        {
            var persons = await Service.GetAllAsync();
            return View(persons);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            var flag=await Service.Create(person);
            if(!flag)
            {
                ModelState.AddModelError("UserName", "نام کاربری قبلا توسط شخص دیگری انتخاب شده است!");
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            
            var person = await Service.Find(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
           
            await Service.Delete(id);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Person person)
        {
           await Service.Update(id, person);
            return RedirectToAction(nameof(Index));
        }

    }
}
