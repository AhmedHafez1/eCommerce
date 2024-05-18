using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email!);

            return new UserDto
            {
                Id = user!.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.GetToken(user)
            };
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> IsEmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.Users.Include(u => u.Address)
                .FirstOrDefaultAsync(user => user.Email == email);

            return _mapper.Map<AddressDto>(user?.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.Users.Include(u => u.Address)
                .FirstOrDefaultAsync(user => user.Email == email);

            user!.Address = _mapper.Map<Address>(addressDto);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) return BadRequest(new ErrorResponse(400));

            return _mapper.Map<AddressDto>(user.Address);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginUser(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ErrorResponse(401));


            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ErrorResponse(401));

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.GetToken(user)
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto registerDto)
        {
            var emailExists = IsEmailExists(registerDto.Email).Result.Value;
            if (emailExists) return BadRequest(new ErrorResponse(400, null, null, ["Email already exists!"]));

            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                DisplayName = registerDto.DisplayName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ErrorResponse(400));

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.GetToken(user)
            };
        }
    }
}
