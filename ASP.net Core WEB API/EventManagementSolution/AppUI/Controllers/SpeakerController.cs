using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("Speakers")]
    public class SpeakersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpeakersController(IHttpClientFactory httpClientFactory)
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

        [Route("List", Name = "SpeakersList")]
        public async Task<IActionResult> GetAllSpeakers()
        {
            var client = GetClient();
            var speakers = await client.GetFromJsonAsync<List<SpeakersDetails>>("api/v3.0/Speakers/GetAll");
            return View(speakers);
        }

        [HttpGet]
        [Route("Add", Name = "AddSpeaker")]
        public IActionResult AddSpeaker()
        {
            return View();
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddSpeaker(SpeakersDetails speaker)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v3.0/Speakers/Add", speaker);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SpeakersList");
            }
            return View(speaker);
        }

        [Route("Edit/{id}", Name = "EditSpeaker")]
        public async Task<IActionResult> UpdateSpeaker(int id)
        {
            var client = GetClient();
            var speaker = await client.GetFromJsonAsync<SpeakersDetails>($"api/v3.0/Speakers/GetById/{id}");
            return View(speaker);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateSpeaker(SpeakersDetails speaker)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync("api/v3.0/Speakers/Update", speaker);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SpeakersList");
            }
            return View(speaker);
        }

        [Route("Delete/{id}", Name = "DeleteSpeaker")]
        public async Task<IActionResult> DeleteSpeaker(int id)
        {
            var client = GetClient();
            var speaker = await client.GetFromJsonAsync<SpeakersDetails>($"api/v3.0/Speakers/GetById/{id}");
            return View(speaker);
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> DeleteSpeaker(SpeakersDetails speaker)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/v3.0/Speakers/Delete/{speaker.SpeakerId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("SpeakersList");
            }
            return View(speaker);
        }
    }
}
