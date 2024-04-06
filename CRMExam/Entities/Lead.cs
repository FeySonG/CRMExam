using CRMExam.Enum;
using System.ComponentModel.DataAnnotations;

namespace CRMExam.Entities
{
    public class Lead
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }

        public Guid SallerId {  get; set; }
        
        public LeadStatus Status { get; set; }
    }
}
