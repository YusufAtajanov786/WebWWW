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
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this._db = applicationDbContext;

        }
        public IEnumerable<SelectListItem> GetFoodTypeListForDropDown()
        {
            return _db.FoodType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });
        }

        public void Update(FoodType foodType)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(i => i.Id == foodType.Id);
            objFromDb.Name = foodType.Name;
            _db.SaveChanges();
        }
    }
}
