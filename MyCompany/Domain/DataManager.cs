using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories { get; set; }
        public IServicesRepository Services { get; set; }   

        public DataManager(IServiceCategoriesRepository servicesCategoriesRepository, IServicesRepository servicesRepository)
        {
            ServiceCategories = servicesCategoriesRepository;
            Services = servicesRepository;
        }

    }
}
