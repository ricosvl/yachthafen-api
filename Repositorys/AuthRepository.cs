using System;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositorys
{
	public class AuthRepository : IAuthService
	{
        private readonly UserDbContext _userDbContext;
        private readonly IUserService _userRepository;

        public AuthRepository(UserDbContext userDbContext, IUserService userRepository )
        {
            _userDbContext = userDbContext;
            _userRepository = userRepository;
        }


        public async Task<User> createUser(User user)
        {
           var checkEmail = await _userRepository.getByEmail(user.email);


            if(checkEmail != null)
            {

                throw new BadHttpRequestException("Email bereits vorhanden");
            }

            var createdUser = await _userDbContext.users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return createdUser.Entity;

        }

        public async Task<User> checkPassword(string password)
        {
            var res = await _userDbContext.users.FirstOrDefaultAsync(e => e.password == password);
            return res;
        }


        public async Task<User> login(string email, string password)
        {
            var checkmail = await _userRepository.getByEmail(email);

            if(checkmail == null)
            {

                throw new BadHttpRequestException("Email ist nicht vorhanden");
            }

            var getPassword = await checkPassword(password);

            if (getPassword == null)
            {
                throw new BadHttpRequestException("Passwörter stimmen nicht miteinander überein");
            }
                

            return checkmail;
        }

    }
}

