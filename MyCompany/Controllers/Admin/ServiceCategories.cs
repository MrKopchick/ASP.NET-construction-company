using MyCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id){
            ServiceCategory? entity = id == default 
                ? new ServiceCategory() 
                : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity){
            if(!ModelState.IsValid) return View(entity);

            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id){
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
