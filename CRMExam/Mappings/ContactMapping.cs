using CRMExam.Contracts;
using Microsoft.Extensions.Hosting;

namespace CRMExam.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ContactDto>()
           .ReverseMap();

        }
       
    }
}
