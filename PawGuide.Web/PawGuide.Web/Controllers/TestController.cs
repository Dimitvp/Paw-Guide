using Microsoft.AspNetCore.Mvc;

namespace PawGuide.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {

            return View();
        }
    }
}
