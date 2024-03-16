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
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserDbContext _userDbContext;
        private readonly IAuthService _authRepository;
        private readonly JwtServices _jwtServices;
        private readonly IConfiguration _config;

        public AuthController(UserDbContext userDbContext, IAuthService authRepository, JwtServices jwtServices, IConfiguration config)
        {
            _userDbContext = userDbContext;
            _authRepository = authRepository;
            _jwtServices = jwtServices;
            _config = config;
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

        [HttpPost("refresh")]
        public async Task<IActionResult> refreshToken([FromBody] RefreshTokenRequestModel model)
        {

            var refreshToken = _jwtServices.generateRefreshToken();

            return Ok(new { RefreshToken = refreshToken });
        }


    }

   
}

public class RefreshTokenRequestModel
{
    public string RefreshToken { get; set; }
}
