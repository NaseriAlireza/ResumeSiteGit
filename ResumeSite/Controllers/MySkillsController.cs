using Microsoft.AspNetCore.Mvc;
using resume.Application.Services;
using resume.Domain.Entities.MySkills;

namespace Resume.presenation.Controllers
{
    public class MySkillsController : Controller
    {
		readonly MySkillsService Service;
		public MySkillsController(MySkillsService _service)
		{
			Service = _service;

		}
		public IActionResult Index()
		{
			var MySkillss = Service.GetAll();
			return View(MySkillss);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(MySkills myskills)
		{
			var flag = await Service.Create(myskills);
			if (!flag)
			{
				ModelState.AddModelError("MySkillsTitle", "نام مهارت مورد نظر قبلا استفاده شده است!");
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
		public async Task<IActionResult> Edit(int id, MySkills myskills)
		{
			await Service.Update(id, myskills);
			return RedirectToAction(nameof(Index));
		}
	}
}

