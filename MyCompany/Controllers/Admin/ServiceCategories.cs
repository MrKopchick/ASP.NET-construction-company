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
            _logger.LogInformation($"Service category {entity.Id} has been updated or added");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id){
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);
            _logger.LogInformation($"Service category {id} has been deleted");
            return RedirectToAction("Index");
        }
    }
}
