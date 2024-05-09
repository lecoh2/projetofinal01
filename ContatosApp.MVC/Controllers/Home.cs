using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.MVC.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
