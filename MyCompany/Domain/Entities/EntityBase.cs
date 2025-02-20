using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace MyCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "заполните название")]
        [Display(Name="Название")]
        [MaxLength(200)]
        public string? Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
