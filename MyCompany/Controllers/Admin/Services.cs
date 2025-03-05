using MyCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace MyCompany.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id){
            Service? entity = id == default ? new Service() : await _dataManager.Services.GetServiceByIdAsync(id);
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile){
            if(!ModelState.IsValid){
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            if(titleImageFile != null){
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Services.SaveServiceAsync(entity);
            _logger.LogInformation($"Service category {entity.Id} has been update or addded");
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id){
            await _dataManager.Services.DeleteServiceAsync(id);
            _logger.LogInformation($"Service {id} has been deleted");
            return RedirectToAction("Index");
        }

    }
}
