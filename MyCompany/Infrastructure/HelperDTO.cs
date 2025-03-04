using MyCompany.Domain.Entities;
using MyCompany.Models;

namespace MyCompany.Infrastructure{
    public class HelperDTO{
        // Service => ServiceDTO
        public static ServiceDTO TransformService(Service entity){
            ServiceDTO entityDTO = new ServiceDTO();
            entityDTO.Id = entity.Id;
            entityDTO.CategoryName = entity.ServiceCategory?.Title;
            entityDTO.Title = entity.Title;
            entityDTO.DescriptionShort = entity.DescriptionShort;
            entityDTO.Description = entity.Description;
            entityDTO.PhotoFileName = entity.Photo;
            entityDTO.Type = entity.Type.ToString();

            return entityDTO;
        }

        public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> entities){
            List<ServiceDTO> entitiesDTO = new List<ServiceDTO>();

            foreach(Service service in entities){
                entitiesDTO.Add(TransformService(service));
            }
            return entitiesDTO;
        }
    }
}