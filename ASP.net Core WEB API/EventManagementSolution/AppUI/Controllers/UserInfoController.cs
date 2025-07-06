using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("user")]
    public class UserInfoController : Controller
    {
        private readonly IHttpClientFactory _http;

        public UserInfoController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory;
        }

        [NonAction]
        private HttpClient GetClient()
        {
            var client = _http.CreateClient("ApiClient");
            return client;
        }

        [Route("")]
        [Route("login", Name = "LoginPage")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginPage(UserInfo user)
        {
            var client = GetClient();
            var res = await client.PostAsJsonAsync("api/v1.0/UserInfo/ValidateUser", user);
            if (res.IsSuccessStatusCode)
            {
                var token = await res.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("jwttoken", token.Trim('"'));
                return RedirectToRoute("EventList");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }
    }
}
