using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Repositorys;
using api.Interfaces;

namespace api.Repositorys
{
	public class UserRepository : IUserService
	{
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


        public async Task<User> deleteUser(int ID) { 


            var res = await _userDbContext.users.FirstOrDefaultAsync(e => e.id == ID);


            if (res != null) 
            {
                _userDbContext.users.Remove(res);
                await _userDbContext.SaveChangesAsync();
                return res;
            }

            return null;
        }

        public async Task<User> getUserById(int id)
        {
            var res = await _userDbContext.users.FirstOrDefaultAsync(e => e.id == id);
            return res;

        }

         public async Task<User> getByEmail(string email)
        {
            var res = await _userDbContext.users.FirstOrDefaultAsync(e => e.email == email);
            return res;
        }

    }
}

