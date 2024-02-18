using System;
using api.Models;

namespace api.Interfaces
{
	public interface IAuthService
	{
		Task<User> createUser(User user);
		Task<User> login(string email, string password);


    }
}

