using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWWW.Models;

namespace WebWWW.DataAccess.Data.Repository.IRepository
{
    public interface IFoodTypeRepository:IRepository<FoodType>
    {
        IEnumerable<SelectListItem> GetFoodTypeListForDropDown();
        void Update( FoodType foodType);
    }
}
