using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWWW.DataAccess.Data.Repository.IRepository;
using WebWWW.Models;

namespace WebWWW.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            this._db = applicationDbContext;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
            _db.SaveChanges();
        }
    }
}
