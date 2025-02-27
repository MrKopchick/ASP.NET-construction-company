using MyCompany.Domain.Entities;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServicesRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServicesAsync();
        Task<ServiceCategory?> GetServiceByIdAsync(int id);
        Task SaveServiceAsync(ServiceCategory entity);
        Task DeleteServiceAsync(int id);
    }
}