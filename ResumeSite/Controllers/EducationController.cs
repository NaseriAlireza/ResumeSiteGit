using Microsoft.AspNetCore.Mvc;
using resume.Application.Services;
using resume.Domain.Entities.Education;

namespace Resume.presenation.Controllers
{
    public class EducationController : Controller
    {
        readonly EducationService Service;
		public EducationController(EducationService _service)
        {
			Service = _service;

		}
        public IActionResult Index()
        {
            var Educations = Service.GetAll();
			return View(Educations);
        }
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Education education)
		{
			var flag = await Service.Create(education);
			if (!flag)
			{
				ModelState.AddModelError("EducationTitle", "نام تحصیلات مورد نظر قبلا استفاده شده است!");
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
		public async Task<IActionResult> Edit(int id, Education education)
		{
			await Service.Update(id, education);
			return RedirectToAction(nameof(Index));
		}
	}
}
