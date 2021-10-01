using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWWW.DataAccess.Data.Repository.IRepository;

namespace WebWWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodTypeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.foodTypeRepository.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.foodTypeRepository.GetFirstOrDefault(i=>i.Id==id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting.." });
            }
            _unitOfWork.foodTypeRepository.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully" });
        }
    }
}
