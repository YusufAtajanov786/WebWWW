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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this._db = applicationDbContext;

        }
      

        public void Update(MenuItem menuItem)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(i => i.Id == menuItem.Id);
            objFromDb.Name = menuItem.Name;
            objFromDb.CategoryId = menuItem.CategoryId;
            objFromDb.FoodTypeId = menuItem.FoodTypeId;
            objFromDb.Price = menuItem.Price;
            if(objFromDb.Image != null)
            {
                objFromDb.Image = menuItem.Image;
            }
            _db.SaveChanges();
        }
    }
}
