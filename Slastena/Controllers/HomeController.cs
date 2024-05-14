using Microsoft.AspNetCore.Mvc;
using Slastena.Models;
using Slastena.ViewModels;

namespace Slastena.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pieRepository = _pieRepository.PiesofWeek;
            var homeViewModel = new HomeViewModel(pieRepository);
            return View(homeViewModel);
        }
    }
}
