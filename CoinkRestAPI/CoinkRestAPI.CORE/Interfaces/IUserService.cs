using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.DTOs;

namespace CoinkRestAPI.CORE.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserPost userDto);
    }

    public interface IUserRepository
    {
        Task<User> CreateUserAsync(UserPost userDto);
    }

}