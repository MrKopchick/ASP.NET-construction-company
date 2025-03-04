using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain.Entities;
using MyCompany.Infrastructure;
using MyCompany.Models;
using MyCompany.Domain;

namespace MyCompany.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;
        public ServicesController(DataManager dataManager){
            _dataManager = dataManager;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);
            return View(listDTO);
        }

        public async Task<IActionResult> Show(int id){
            Service? entity = await _dataManager.Services.GetServiceByIdAsync(id);

            if(entity is null){
                return NotFound();  
            }

            ServiceDTO dto = HelperDTO.TransformService(entity);

            return View(dto);
        }
    }
}
