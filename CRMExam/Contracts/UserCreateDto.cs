namespace CRMExam.Contracts
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(300)]
        public  required string FullName { get; set; }

        [Required]
        [StringLength(200)]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }
}
