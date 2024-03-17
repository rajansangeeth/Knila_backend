using AutoMapper;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController:Controller
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ApplicationDbContext _context;
        private ITokenHandler _tokenHandler;
        public AuthController(IUserRepository userRepository, IMapper mapper, ApplicationDbContext context, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _mapper= mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto model)
        {
            bool isUnique = _userRepository.IsUnique(model.Email);
            if (isUnique)
            {
                return BadRequest("Email already exists");
            }
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User created successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == model.Email && a.Password == model.Password);
            if (user == null)
            {
                return BadRequest("Email or Password is wrong");
            }
            var token = _tokenHandler.CreateTokenAsync(user);
            return Ok(token);
        }
    }
}
