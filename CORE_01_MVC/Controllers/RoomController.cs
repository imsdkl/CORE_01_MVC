using CORE_01_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CORE_01_MVC.Controllers
{
    public class RoomController : Controller
    {
        ContextDb db = null;
        public RoomController(ContextDb db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetFileForm()
        {
            return View();
        }
        public IActionResult GetForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostForm(string name, List<IFormFile> upfiles)
        {
            foreach (var formfile in upfiles)
            {
                if (formfile.Length > 0)
                {
                    string fp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", formfile.FileName);
                    using (var stream = System.IO.File.Create(fp))
                    {
                        formfile.CopyTo(stream);
                        // db.Pictures.Add(new Models.Picture { Name = name, Path = formfile.FileName});
                        db.Add(name, formfile.FileName);
                    }
                };
            };
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Picture picture = db.Get(id);
            if (picture != null)
            {
                ViewBag.id = picture.Id;
                ViewBag.name = picture.Name;
            }
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult UpdForm(int id, string name, List<IFormFile> upfiles)
        {

            foreach (var formfile in upfiles)
            {
                string fp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", formfile.FileName);
                FileInfo file = new FileInfo(fp);
                if (file.Exists)
                {
                    file.Delete();
                }
                using (var stream = System.IO.File.Create(fp))
                {
                    formfile.CopyTo(stream);
                    //db.Pictures.Add(new Models.Picture { Name = name, Path = formfile.FileName });
                    db.Update(id, name, formfile.FileName);
                }
            };
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
