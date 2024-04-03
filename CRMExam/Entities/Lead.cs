using CRMExam.Enum;

namespace CRMExam.Entities
{
    public class Lead
    {
            public Guid Id { get; set; }
        public Guid ContractId { get; set; }

        public Guid SallerId {  get; set; }
        
        public LeadStatus Status { get; set; }
    }
}
