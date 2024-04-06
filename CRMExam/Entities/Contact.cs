using CRMExam.Enum;
using System.ComponentModel.DataAnnotations;

namespace CRMExam.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MarketingId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string Patronymic { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public ContactStatus Status { get; set; }

        [Required]
        public DateTime DateOfChange { get; set; }
    }
}
