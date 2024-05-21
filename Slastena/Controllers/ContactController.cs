using Microsoft.AspNetCore.Mvc;

namespace Slastena.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
