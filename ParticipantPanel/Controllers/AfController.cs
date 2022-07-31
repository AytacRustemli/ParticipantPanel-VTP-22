using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class AfController : Controller
    {
        private readonly AfServices _afServices;

        public AfController(AfServices afServices)
        {
            _afServices = afServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Afs = _afServices.GetAll()
            };
            return View(homeVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Af af)
        {
            try
            {
                _afServices.Create(af);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _afServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
