using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.API.Models;
using Application.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJsonUserService _jsonUserService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, 
            IJsonUserService jsonUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jsonUserService = jsonUserService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(JObject credentials)
        {
            try
            {
                User user = _jsonUserService.ParseUser(credentials);
                var result = await _userManager.CreateAsync(user, _jsonUserService.GetPassword(credentials));
                if (result.Succeeded)
                {
                    return Created("", user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (NullReferenceException)
            {
                return BadRequest("body is invalid");
            }
           
        }
    }
}