using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Dtos.ContactDtos;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
          {
                _context = context;
          }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values= _context.Contacts.ToList();
            return Ok(values);


        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto create)
        {

           Contact contact = new Contact();
            contact.Email = create.Email;
            contact.Address = create.Address;
            contact.Phone = create.Phone;
            contact.MapLocation = create.MapLocation;
            contact.OpenHours=create.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("ekleme işlemi yapıldı");
        }
    }
}
