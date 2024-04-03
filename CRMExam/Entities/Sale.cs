namespace CRMExam.Entities
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public Guid LeadId { get; set; }
        public Guid Seller {  get; set; }
        public DateTime DateOfSale { get; set; }

    }
}
