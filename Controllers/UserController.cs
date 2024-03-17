using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Repositorys;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserDbContext _userDbContext;
        private readonly IUserService _userRepository;

        public UserController(UserDbContext userDbContext, IUserService userRepository)
        {
            _userDbContext = userDbContext;
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> getAllUser()
        {

            try
            {
                var user = await _userDbContext.users.ToListAsync();

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> findUserById(int id)
        {
            try
            {
                var user = await _userRepository.getUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error retrieving data from the database");
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> deleteUSer(int id)
        {
            try
            {
                var users = await _userRepository.deleteUser(id);
                return Ok(User);

            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }
        }

        [HttpGet("getByEmail")]
        public async Task<IActionResult> getUserByEmail(string email)
        {
            try
            {
                var userMail = await _userRepository.getByEmail(email);
                return Ok(userMail);

            } catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error retrieving data from the database");
            }

        }
    }
}
