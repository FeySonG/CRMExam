using System.ComponentModel;

namespace CRMExam.Contracts
{
    public class ContactDto
    {
        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        public required string Name { get; set; }

        [MaxLength(100, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        [DisplayName("Surname")]
        public string Surname { get; set; } = string.Empty;

        [DisplayName("Patronymic")]
        [MaxLength(100, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        public string Patronymic { get; set; } = string.Empty;

        [DisplayName("Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessage.REQUIRED)]
        [MaxLength(14, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        [Phone(ErrorMessage = ValidationMessage.PHONE)]
        public required string PhoneNumber { get; set; }

        [MaxLength(150, ErrorMessage = ValidationMessage.MAX_LENGTH)]
        [EmailAddress(ErrorMessage = ValidationMessage.EMAIL)]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Роль пользователя")]
        [Required(ErrorMessage = ValidationMessage.REQUIRED)]
        [EnumDataType(typeof(ContactStatus), ErrorMessage = ValidationMessage.CONTACT_ENUM)]
        public ContactStatus Status { get; set; }
    }
}
