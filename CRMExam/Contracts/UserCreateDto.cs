using System.ComponentModel;

namespace CRMExam.Contracts
{
    public class UserCreateDto
    {
        [DisplayName("FullName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(150, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        public  required string FullName { get; set; }

        [DisplayName("Email Adress")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(150, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        [EmailAddress(ErrorMessage = ValidationMessage.EMAIL)]
        public required string Email { get; set; }

        [DisplayName("Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        public required string Password { get; set; }

        [DisplayName("User Role")]
        [Required(ErrorMessage = ValidationMessage.REQUIRED)]
        [EnumDataType(typeof(UserRole), ErrorMessage = ValidationMessage.USER_ENUM)]
        public UserRole Role { get; set; }
    }
}
