using Microsoft.AspNetCore.Hosting;
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
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._webHostEnvironment = webHostEnvironment;
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
