using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserDbContext _userDbContext;
        private readonly IAuthService _authRepository;

        public AuthController(UserDbContext userDbContext, IAuthService authRepository)
        {
            _userDbContext = userDbContext;
            _authRepository = authRepository;
        }


        [HttpPost("register")]
        public async Task<IActionResult> addUser(User user)
        {
            var res = await _authRepository.createUser(user);
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(fillabileFields user)
        {
            var loginUser = await _authRepository.login(user.email, user.password);
            return Ok(loginUser);
        }
    }
}
