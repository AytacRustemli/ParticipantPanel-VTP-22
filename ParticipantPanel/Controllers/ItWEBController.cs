using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;
using Services;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class ItWEBController : Controller
    {
        private readonly ItWEBServices _services;

        public ItWEBController(ItWEBServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Itweb = _services.GetAll()
            };
            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(ItWeb itweb)
        {
            try
            {
                _services.Create(itweb);
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
