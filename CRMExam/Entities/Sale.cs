

namespace CRMExam.Entities
{
    public class Sale
    {
        [Key]
        public Guid SaleId { get; set; } = Guid.NewGuid();
        public Guid LeadId { get; set; }
        public Guid SallerId {  get; set; }
        public DateTime DateOfSale { get; set; } = DateTime.Now;    

    }
}
