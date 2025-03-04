using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public AdminController(DataManager dataManager, IWebHostEnvironment hostingEnviroment)
        {
            _dataManager = dataManager;
            _hostingEnviroment = hostingEnviroment;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
            ViewBag.Services = await _dataManager.Services.GetServicesAsync();
            return View(); 
        }

        public async Task<string> SaveImg(IFormFile img)
        {
            string path = Path.Combine(_hostingEnviroment.WebRootPath, "img/", img.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await img.CopyToAsync(stream);

            return path;
        }
    }
}
