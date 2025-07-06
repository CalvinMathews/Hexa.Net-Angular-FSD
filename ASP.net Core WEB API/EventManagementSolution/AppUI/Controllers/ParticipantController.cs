using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("participants")]
    public class ParticipantController : Controller
    {
        private readonly IHttpClientFactory _http;

        public ParticipantController(IHttpClientFactory http)
        {
            _http = http;
        }

        [NonAction]
        private HttpClient GetClient()
        {
            var client = _http.CreateClient("ApiClient");
            var token = HttpContext.Session.GetString("jwttoken");
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Trim('"');
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [Route("list", Name = "ParticipantList")]
        public async Task<IActionResult> List()
        {
            var client = GetClient();
            var list = await client.GetFromJsonAsync<List<ParticipantEventDetails>>("api/v3.0/ParticipantEventDetails/GetAll");
            return View(list);
        }

        [Route("add", Name = "AddParticipant")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(ParticipantEventDetails participant)
        {
            var client = GetClient();
            var res = await client.PostAsJsonAsync("api/v3.0/ParticipantEventDetails/Register", participant);
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");

            return View(participant);
        }

        [Route("edit/{id}", Name = "EditParticipant")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit(ParticipantEventDetails participant)
        {
            var client = GetClient();
            var res = await client.PutAsJsonAsync("api/v3.0/ParticipantEventDetails/Update", participant);
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");

            return View(participant);
        }

        [Route("delete/{id}", Name = "DeleteParticipant")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteConfirmed(int participantId)
        {
            var client = GetClient();
            var res = await client.DeleteAsync($"api/v3.0/ParticipantEventDetails/Delete/{participantId}");
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");

            return View();
        }

        [Route("details/{id}", Name = "ParticipantDetails")]
        public async Task<IActionResult> Details(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(data);
        }
    }
}
