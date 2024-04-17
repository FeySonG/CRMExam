namespace CRMExam.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserInfoDto>()
                .ReverseMap();

            CreateMap<User, UserCreateDto>()
                .ReverseMap();
        }
    }
}
