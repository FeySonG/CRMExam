using CRMExam.Enum;

namespace CRMExam.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public Guid MarketingId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymicl { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ContactStatus Status { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}
