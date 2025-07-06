using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("Session")]
    public class SessionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SessionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [NonAction]
        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var token = HttpContext.Session.GetString("jwttoken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            }
            return client;
        }

        [Route("List", Name = "SessionList")]
        public async Task<IActionResult> GetAllSessions()
        {
            var client = GetClient();
            var sessions = await client.GetFromJsonAsync<List<Session>>("api/v3.0/Session/GetAll");
            return View(sessions);
        }

        [HttpGet]
        [Route("Add", Name = "AddSession")]
        public IActionResult AddSession()
        {
            return View();
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddSession(Session session)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v3.0/Session/Add", session);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SessionList");
            }
            return View(session);
        }

        [Route("Edit/{id}", Name = "EditSession")]
        public async Task<IActionResult> UpdateSession(int id)
        {
            var client = GetClient();
            var session = await client.GetFromJsonAsync<Session>($"api/v3.0/Session/GetById/{id}");
            return View(session);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateSession(Session session)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync("api/v3.0/Session/Update", session);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SessionList");
            }
            return View(session);
        }

        [Route("Delete/{id}", Name = "DeleteSession")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var client = GetClient();
            var session = await client.GetFromJsonAsync<Session>($"api/v3.0/Session/GetById/{id}");
            return View(session);
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> DeleteSession(Session session)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/v3.0/Session/Delete/{session.Id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SessionList");
            }
            return View(session);
        }
    }
}
