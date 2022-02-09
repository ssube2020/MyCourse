using Microsoft.AspNetCore.Mvc;
using MyCourse.Services;

namespace MyCourse.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IAppointmentService _appservice;
        public AppointmentController(IAppointmentService appservice)
        {
            _appservice = appservice;
        }
        public IActionResult Index()
        {
            var doctors = _appservice.GetDoctors();
            ViewBag.doctors = doctors;
            var patients = _appservice.GetPatients();
            return View(doctors);
        }
    }
}
