using System.Diagnostics;
using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.Models;
using ParticipantPanel.ViewModels;
using Services;

namespace ParticipantPanel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CountServices _countServices;
        private readonly ItWEBServices _itWebServices;
        private readonly AfServices _afServices;
        private readonly ItRmServices _ceeServices;
        private readonly HrServices _hrServices;
        private readonly LogisticServices _logisticServices;

        public HomeController(ILogger<HomeController> logger, CountServices countServices, ItWEBServices itWebServices, AfServices afServices, ItRmServices ceeServices, HrServices hrServices, LogisticServices logisticServices)
        {
            _logger = logger;
            _countServices = countServices;
            _itWebServices = itWebServices;
            _afServices = afServices;
            _ceeServices = ceeServices;
            _hrServices = hrServices;
            _logisticServices = logisticServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<int> ages = new List<int>();
            List<int> ageCounts = new List<int>();

            HomeVM homeVM = new()
            {
                Itweb = _itWebServices.GetAll(),
                itWebCount = _itWebServices.GetCount(),
                afCount = _afServices.GetCount(),
                ceCount = _ceeServices.GetCount(),
                hrCount = _hrServices.GetCount(),
                logistics = _logisticServices.GetAll(),
                lgCount = _logisticServices.GetCount(),
                ages = ages,
                ageCounts = ageCounts
            };


            foreach (AgePercentage item in _itWebServices.GetAgePercentage())
            {
                ages.Add(item.Age);
                ageCounts.Add(item.AgeCount);
            }

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}