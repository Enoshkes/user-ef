using Microsoft.Identity.Client;

namespace user_app.Dto
{
    public record UserDto(int Id, string Username, string Email, byte[]? Image, DateTime CreatedAt);
}
