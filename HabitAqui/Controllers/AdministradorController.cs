using Microsoft.AspNetCore.Mvc;

namespace HabitAqui.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
