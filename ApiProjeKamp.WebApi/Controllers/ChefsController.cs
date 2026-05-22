using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext apiContext;
        public ChefsController(ApiContext context)
        {


            apiContext = context;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = apiContext.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult ChefPut(Chef chef)
        {
            apiContext.Chefs.Add(chef);
            apiContext.SaveChanges();
            return Ok("Yeni chef ler eklendi");
        }
        [HttpDelete]
        public IActionResult ChefDelete(int id)
        {
            var values = apiContext.Chefs.Find(id);
            apiContext.Chefs.Remove(values);
            apiContext.SaveChanges();
            return Ok("İstenen Id ye sahip kişinin kaydı güvenli bir şekilde silindi");

        }
        [HttpPut]
        public IActionResult ChefUpdate(Chef chef)
        {
            apiContext.Chefs.Update(chef);
            apiContext.SaveChanges();
            return Ok("istenen değere sahip kişinin bilgileri güncellendi");
        }
    }
}