using ClientService_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class ClientController : Controller
{
    private static List<ClientInfo> _clients = new List<ClientInfo>();

    //private static int _nextId = 1;

    [Route("")]
    [Route("Clients")]
    [Route("Clients/ShowAll")]
    public ActionResult ShowAllClientDetails()
    {
        return View(_clients);
    }

    [Route("Clients/ById/{id}")]
    public ActionResult GetDetailsByClientId(int id)
    {
        var client = _clients.FirstOrDefault(c => c.ClientId == id);
        return View(client);
    }

    [Route("Clients/ByCompany/{name}")]
    public ActionResult GetDetailsByCompanyName(string name)
    {
        var client = _clients.FirstOrDefault(c => c.CompanyName == name);
        return View(client);
    }

    [Route("Clients/ByEmail/{email}")]
    public ActionResult GetDetailsByEmail(string email)
    {
        var client = _clients.FirstOrDefault(c => c.Email == email);
        return View(client);
    }

    [Route("Clients/ByCategory/{category}")]
    public ActionResult GetDetailsByCategory(string category)
    {
        var clients = _clients.Where(c => c.Category == category).ToList();
        return View(clients);
    }

    [Route("Clients/ByStandard/{standard}")]
    public ActionResult GetDetailsByStandard(string standard)
    {
        var clients = _clients.Where(c => c.Standard == standard).ToList();
        return View(clients);
    }

    [Route("Clients/Add")]
    public ActionResult AddClient()
    {
        return View();
    }
    [HttpPost]
    [Route("Clients/Add")]
    public ActionResult AddClient(ClientInfo clientInfo)
    {
        

        _clients.Add(clientInfo);

        // Redirect to show all clients
        return RedirectToAction("ShowAllClientDetails");
    }
}