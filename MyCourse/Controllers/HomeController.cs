using Microsoft.AspNetCore.Mvc;
using MyCourse.Models;
using System.Diagnostics;

namespace MyCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //[Route("Home/Index/id")]
        public ActionResult Index(int id)
        {
            string todaysdate = DateTime.Now.ToString();
            return Content("you have entered on date: " + todaysdate + id);  
        }

        [Route("home/privacy/id/name/surname")]
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