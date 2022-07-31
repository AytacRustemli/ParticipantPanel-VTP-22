using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class LogisticController : Controller
    {
        private readonly LogisticServices _services;

        public LogisticController(LogisticServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                logistics = _services.GetAll()
            };
            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Logistic logistic)
        {
            try
            {
                _services.Create(logistic);
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
