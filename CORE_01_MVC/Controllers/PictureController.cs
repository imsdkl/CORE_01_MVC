using CORE_01_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_01_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        Models.ContextDb db = null;
        public PictureController(Models.ContextDb context)
        {
            db = context;
        }

        [HttpGet]
        public Models.Picture[] GetAll()
        {
            return db.GetAll();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Delete(id);
        }

        [HttpPost]
        public void Post([FromForm] string name, [FromForm] params IFormFile[] upfiles)
        {
            foreach(var formfile in upfiles)
            {
                if (formfile.Length > 0)
                {
                    string fp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", formfile.FileName);
                    using(var stream = System.IO.File.Create(fp))
                    {
                        formfile.CopyTo(stream);
                        db.Add(name, formfile.FileName);
                    }
                };
            };
            db.SaveChanges();
            // +Path.GetFileNameWithoutExtensions(formfile.FileName)
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
            return;
        }
    }
}
