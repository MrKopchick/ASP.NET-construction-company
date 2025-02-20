namespace MyCompany.Domain.Entities
{
    public class ServiceCategory : EntityBase
    {
        public ICollection<Service>? Services { get; set; } = new List<Service>();
    }
}
