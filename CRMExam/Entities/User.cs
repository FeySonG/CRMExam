

namespace CRMExam.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(300) ]
        public string? FullName { get; set; }

        [Required]
        [StringLength(200)]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        
        public   UserRole Role { get; set; }


    }
}
