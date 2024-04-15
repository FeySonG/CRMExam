using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;



namespace CRMExam.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly HttpContext _httpContext;
        public UserService(IHttpContextAccessor accessor, AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }

            _httpContext = accessor.HttpContext;
        }



        public async Task<UserCreateDto?> AddUserAsync(UserCreateDto user)
        {
            var newUser = _mapper.Map<User>(user);
            if (newUser == null) return null;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> LogInAsync(UserLoginDto credentials)
        {
            var authUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email && u.Password == credentials.Password);
            if (authUser == null) return null;

            await LoginHttpContext(authUser);
            return authUser;

        }

        public async Task<List<User>> Users()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<UserDto> UserInfoAsync()
        {
            var userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Id.ToString() == userId);


            var userDto = _mapper.Map<UserDto>(foundUser);

            return userDto;
        }

        public async Task<bool> KillUser(Guid id)
        {
           var target =  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if(target == null) return false;  
            if (target.Role == UserRole.admin ) return false;

             _context.Users.Remove(target);
            await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> ChangeRoleAsync(Guid id, UserRole role)
        {
           var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null; 

            user.Role = role;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

           var userDto =  _mapper.Map<UserDto>(user);
            return userDto;
        }
        public async Task<bool> ChangePasswordAsync(string newPassword)
        {
            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (Guid.TryParse(stringId, out Guid guidId) == false) return false;

            var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == guidId);
            if (user == null) return false;
            user.Password = newPassword;
           _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

           


        private Task LoginHttpContext(User user)
        {

            var claims = new Claim[]
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString() ),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, user.Role.ToString()),
                new (ClaimTypes.Expiration, DateTime.UtcNow.AddHours(1).ToString()),
            };
            var identity = new ClaimsIdentity(claims, "Coockies");
            var principal = new ClaimsPrincipal(identity);

            return _httpContext.SignInAsync(principal);
        }
    }
}
