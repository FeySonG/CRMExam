namespace CRMExam.Contracts
{
    public class ContactDto
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; } = string.Empty;

        [StringLength(100)]
        public string Patronymic { get; set; } = string.Empty;

        [Required]
        public required string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public ContactStatus Status { get; set; }
    }
}
