using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("Learner")]
    public class LearnerController : Controller
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

        [Route("Search")]
        public IActionResult SearchContent()
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