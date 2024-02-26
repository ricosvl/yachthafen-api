using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using api.Interfaces;
using api.Services;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserDbContext _userDbContext;
        private readonly IAuthService _authRepository;
        private readonly JwtServices _jwtServices;

        public AuthController(UserDbContext userDbContext, IAuthService authRepository, JwtServices jwtServices)
        {
            _userDbContext = userDbContext;
            _authRepository = authRepository;
            _jwtServices = jwtServices;
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

            var token = _jwtServices.generateToken(loginUser);
            return Ok(new { token, loginUser });
        }

        [HttpGet("me")]
        public async Task<IActionResult> getLoggedInUser() 
        {

            var loggedInUser = HttpContext.User;

            return Ok(loggedInUser);
        }
    }
}
