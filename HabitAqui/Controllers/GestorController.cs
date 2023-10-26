using Microsoft.AspNetCore.Mvc;

namespace HabitAqui.Controllers
{
    public class GestorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
