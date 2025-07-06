using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("events")]
    public class EventController : Controller
    {
        private readonly IHttpClientFactory _http;

        public EventController(IHttpClientFactory http)
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

        [Route("list", Name = "EventList")]
        public async Task<IActionResult> List()
        {
            var client = GetClient();
            var evts = await client.GetFromJsonAsync<List<EventDetails>>("api/v2.0/EventDetails/GetAll");
            return View(evts);
        }

        [HttpGet]
        [Route("add", Name = "AddEvent")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add(EventDetails evt)
        {
            var client = GetClient();
            var res = await client.PostAsJsonAsync("api/v2.0/EventDetails/SaveEvent", evt);
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("EventList");

            return View(evt);
        }

        [Route("edit/{id}", Name = "EditEvent")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(evt);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Edit(EventDetails evt)
        {
            var client = GetClient();
            var res = await client.PutAsJsonAsync("api/v2.0/EventDetails/UpdateEvent", evt);
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("EventList");

            return View(evt);
        }

        [Route("delete/{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(evt);
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Delete(EventDetails evt)
        {
            var client = GetClient();
            var token = HttpContext.Session.GetString("jwttoken")?.Trim('"');
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var res = await client.DeleteAsync($"api/v2.0/EventDetails/DeleteEvent/{evt.EventId}");
            if (res.IsSuccessStatusCode)
                return RedirectToRoute("EventList");

            return View();
        }

        [Route("details/{id}", Name = "EventDetails")]
        public async Task<IActionResult> Details(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(evt);
        }
    }
}
