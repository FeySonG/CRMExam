using System.ComponentModel;

namespace CRMExam.Contracts
{
   
    public class LeadDto
    {
        [Required]
        public Guid ContractId { get; set; }

        [Required]
        public Guid SallerId { get; set; }

        [DisplayName("User Role")]
        [Required(ErrorMessage = ValidationMessage.REQUIRED)]
        [EnumDataType(typeof(UserRole), ErrorMessage = ValidationMessage.LEAD_ENUM)]
        public LeadStatus Status { get; set; }
    }
}
