using System;
using api.Models;

namespace api.Interfaces
{
    public interface IUserService
    {
        Task<User> deleteUser(int id);
        Task<User> getUserById(int id);
        Task<User> getByEmail(string email);
    }
}

