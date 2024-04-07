

namespace CRMExam.Entities
{
    public class Lead
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public  Guid ContractId { get; set; }

        [Required]
        public Guid SallerId {  get; set; }

        [Required]
        public LeadStatus Status { get; set; }
    }
}
