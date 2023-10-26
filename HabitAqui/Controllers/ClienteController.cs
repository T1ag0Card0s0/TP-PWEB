using Microsoft.AspNetCore.Mvc;

namespace HabitAqui.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
