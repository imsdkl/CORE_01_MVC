using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CORE_01_MVC.Models
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Picture> Pictures { get; set; }

        #region GetAll
        public Picture[] GetAll()
        {
            Picture[] rc = Pictures.ToArray<Picture>();
            return rc;
        }
        #endregion

        #region Get(ID)
        public Picture Get(int id)
        {
            Picture picture = Pictures.Find(id);
            return picture;
        }
        #endregion

        #region Add
        public void Add(string name, string path)
        {
            Pictures.Add(new Models.Picture { Name = name, Path = path});
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Picture delete = Pictures.Find(id);
            if (delete != null) Pictures.Remove(delete);
            SaveChanges();
        }
        #endregion

        #region Update
        public void Update(int id, string name, string path)
        {
            Picture picture = Get(id);
            if (picture != null)
            {
                picture.Name = name;
                picture.Path = path;
            }
        }
        #endregion
    }
}
