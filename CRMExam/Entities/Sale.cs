using System.ComponentModel.DataAnnotations;

namespace CRMExam.Entities
{
    public class Sale
    {
        [Key]
        public Guid SaleId { get; set; }
        public Guid LeadId { get; set; }
        public Guid SellerId {  get; set; }
        public DateTime DateOfSale { get; set; }

    }
}
