using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class ItRmController : Controller
    {
        private readonly ItRmServices _services;

        public ItRmController(ItRmServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                ItRms = _services.GetAll()
            };
            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItRm ce)
        {
            try
            {
                _services.Create(ce);
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
