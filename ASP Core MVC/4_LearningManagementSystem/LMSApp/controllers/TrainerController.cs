using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Controllers
{
    [Route("Trainer")]
    public class TrainerController : Controller
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

        [Route("Content")]
        public IActionResult ManageContent()
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