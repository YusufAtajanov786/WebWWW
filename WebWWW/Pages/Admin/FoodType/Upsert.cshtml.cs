using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWWW.DataAccess.Data.Repository.IRepository;

namespace WebWWW.Pages.Admin.FoodType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Models.FoodType FoodType { get; set; }
        public IActionResult OnGet(int? id)
        {
            FoodType = new Models.FoodType();
            if (id != null)
            {
                FoodType = _unitOfWork.foodTypeRepository.GetFirstOrDefault(i => i.Id == id);
                if (FoodType == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FoodType.Id == 0)
            {
                _unitOfWork.foodTypeRepository.Add(FoodType);
            }
            else
            {
                _unitOfWork.foodTypeRepository.Update(FoodType);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
