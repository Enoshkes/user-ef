using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using user_app.Data;
using user_app.Dto;
using user_app.Models;
using static user_app.Utils.ImageUtils;

namespace user_app.Service
{
    public class UserService(ApplicationDbContext context) : IUserService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<UserDto> CreateUser(CreateUserDto user)
        {
            UserModel userModel = new()
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Image = await ConvertFromIFormFile(user.Image),

            };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return new (
                userModel.Id, userModel.Username, userModel.Email, 
                userModel.Image, userModel.CreatedDate
            );
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _context.Users
                .Select(user => new UserDto(
                    user.Id, user.Username, user.Email, user.Image, user.CreatedDate
                    )
                )
                .ToListAsync();
        }

        public async Task<UserDto?> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user switch
            {
                null => null,
                _ => new(
                    user.Id, user.Username, user.Email, user.Image, user.CreatedDate
                )
            };
        }
    }
}
