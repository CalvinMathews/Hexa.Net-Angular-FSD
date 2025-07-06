using Microsoft.AspNetCore.Mvc;
using LMSApp.Models;

namespace LMSApp.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Admin/Login")]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [Route("Trainer/Login")]
        public IActionResult TrainerLogin()
        {
            return View();
        }

        [Route("Learner/Login")]
        public IActionResult LearnerLogin()
        {
            return View();
        }
    }
}