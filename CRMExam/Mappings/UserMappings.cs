namespace CRMExam.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<User, UserCreateDto>()
                .ReverseMap();
        }
    }
}
