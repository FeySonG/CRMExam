using CRMExam.Enum;
using System.ComponentModel.DataAnnotations;

namespace CRMExam.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(300) ]
        public string FullName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public UserRole Role { get; set; }


    }
}
