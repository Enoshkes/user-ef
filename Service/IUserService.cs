using user_app.Dto;

namespace user_app.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto?> GetById(int id);
        Task<UserDto> CreateUser(CreateUserDto user);
    }
}
