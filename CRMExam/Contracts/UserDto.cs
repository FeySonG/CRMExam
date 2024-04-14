namespace CRMExam.Contracts
{
    public class UserDto
    {
        [StringLength(300)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(200)]
        public required string Email { get; set; }

        public UserRole Role { get; set; }
    }
}
