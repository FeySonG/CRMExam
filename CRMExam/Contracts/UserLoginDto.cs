namespace CRMExam.Contracts
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(200)]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
