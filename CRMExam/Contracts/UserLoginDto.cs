using System.ComponentModel;

namespace CRMExam.Contracts
{
    public class UserLoginDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(150, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        [EmailAddress(ErrorMessage = ValidationMessage.EMAIL)]
        public required string Email { get; set; }

        [DisplayName("Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        public required string Password { get; set; }
    }
}
