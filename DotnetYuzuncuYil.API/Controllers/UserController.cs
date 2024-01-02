using AutoMapper;
using DotnetYuzuncuYil.API.Abstraction;
using DotnetYuzuncuYil.Core.DTOs;
using DotnetYuzuncuYil.Core.DTOs.Authentication;
using DotnetYuzuncuYil.Core.Models;
using DotnetYuzuncuYil.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AuthResponseDto = DotnetYuzuncuYil.Core.DTOs.AuthResponseDto;

namespace DotnetYuzuncuYil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public UserController(IMapper mapper, IUserService userService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _mapper = mapper;
            _userService = userService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        //api/user/1
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserProfileDto>>(users.ToList());
            return CreateActionResult(GlobalResultDto<List<UserProfileDto>>.Success(200, usersDto));
        }
        [HttpGet("{id}")]
        //Get api/user/3
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            var UserProfileDto = _mapper.Map<UserProfileDto>(user);
            return CreateActionResult(GlobalResultDto<UserProfileDto>.Success(200, UserProfileDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserProfileDto UserProfileDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(UserProfileDto));//teamDtoyu Team entitye çevirme.
            var UserProfileDtos = _mapper.Map<UserProfileDto>(user);
            return CreateActionResult(GlobalResultDto<UserProfileDto>.Success(201, UserProfileDtos));

        }
        [HttpPut]
        public async Task<IActionResult> Update(UserProfileDto UserProfileDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(UserProfileDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetById(id);
            await _userService.RemoveAsync(user);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(AuthRequestDto authDto)
        {
            #region Password'un hashli halini veri tabanına göndermek için güncelleme yap
            var passwordHash = _userService.GeneratePasswordHash(authDto.UserName, authDto.Password);
            #endregion

            var user = await _userService.AddAsync(new User
            {
                Email = authDto.Email,
                Password = passwordHash,
                UserName = authDto.UserName,
            });
            var usersDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(GlobalResultDto<UserDto>.Success(201, usersDto));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            UserDto user = _userService.FindUser(authDto.UserName, authDto.Password);

            if(user == null)
            {
                return CreateActionResult(GlobalResultDto<NoContentDto>.Success(401));
            }
            else
            {
                responseDto = _jwtAuthenticationManager.Authenticate(authDto.UserName,authDto.Password);

                if(responseDto == null)
                {
                    return CreateActionResult(GlobalResultDto<NoContentDto>.Success(401));
                }
                else
                {
                    responseDto.User = user;

                }
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, responseDto));

            }
        }

    }
}
