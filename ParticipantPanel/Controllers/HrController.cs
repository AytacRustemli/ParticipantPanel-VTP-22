using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class HrController : Controller
    {
        private readonly HrServices _services;

        public HrController(HrServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                HRs = _services.GetAll()
            };
            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HR hr)
        {
            try
            {
                _services.Create(hr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
