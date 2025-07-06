using Microsoft.AspNetCore.Mvc;
using ContactDelivery_MVC.Models;

namespace ContactDelivery_MVC.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        
        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        public ActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId ==id);
            if (contact != null)
            {
                return View(contact);
            }
            else
            {
                return NotFound("Contact not found");
            }
        }

        public ActionResult AddContact()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            contactInfo.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}
