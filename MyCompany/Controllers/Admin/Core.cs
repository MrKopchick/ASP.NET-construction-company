using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnviroment;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DataManager dataManager, IWebHostEnvironment hostingEnviroment, ILogger<AdminController> logger)
        {
            _dataManager = dataManager;
            _hostingEnviroment = hostingEnviroment;
            _logger = logger;
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

        public async Task<string> SaveEditorImg(){
            IFormFile img = Request.Form.Files[0];
            await SaveImg(img);

            return JsonSerializer.Serialize(new {location = Path.Combine("/img/", img.FileName)});
        }
    }
}
