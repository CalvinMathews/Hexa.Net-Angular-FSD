using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Route("")]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("UpdateProfile")]
        public IActionResult UpdateProfile()
        {
            return View();
        }

        [Route("Courses")]
        public IActionResult ManageCourses()
        {
            return View();
        }

        [Route("Trainers")]
        public IActionResult ManageTrainers()
        {
            return View();
        }

        [Route("Learners")]
        public IActionResult ManageLearners()
        {
            return View();
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}