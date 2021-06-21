using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    public class DanhMucDao
    {
        private DangMinhHieuDbEntities db = new DangMinhHieuDbEntities();
        public IEnumerable<Category> getDanhMuc()
        {
            return (IEnumerable<Category>)db.Category.ToList();
        }
        public void addCategory(Category category) {
            db.Category.Add(category);
            db.SaveChanges();
        }
        public void updateCategory(Category category)
        {
            var dm = db.Category.Where(x => x.CategoryID == category.CategoryID).SingleOrDefault();
            dm.Name = category.Name;
            dm.Description = category.Description;
            db.SaveChanges();
        }
        public void deleteCategory(int id)
        {
            var dm = db.Category.Where(x => x.CategoryID == id).SingleOrDefault();
            db.Category.Remove(dm);
            db.SaveChanges();
        }
    }
}
