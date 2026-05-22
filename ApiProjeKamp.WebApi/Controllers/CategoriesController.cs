using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {    private readonly ApiContext _context;
        
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]//Herhangi bir işlemin başına neden yaptığımız için gerekli olan etribute ü eklemezsek hata alırız.
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]//Ekleme işlemleri için kullanılan bir etribute tur.
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarlı bir şekilde yapıldı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {

            var values = _context.Categories.Find(id);
            _context.Categories.Remove(values);
            _context.SaveChanges();
            var list = _context.Categories.ToList();
            return Ok(list);
        }

        [HttpGet("GetCatgory")]//Bir sayfa da bir etribute tan birden fazla olunca hata verir o yüzden birdan fazla kullanacağımız zaman adlandırmalar yapmalıyız.
        public IActionResult GetCategory(int id)
        {

            var value=_context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı bir şekilde yapıldı.");
        }
    }
}
