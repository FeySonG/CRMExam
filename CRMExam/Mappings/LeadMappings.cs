namespace CRMExam.Mappings
{
    public class LeadMappings : Profile
    {
        public LeadMappings()
        {
            CreateMap<Contact, Lead>()
           .ReverseMap();

        }
    }
}
