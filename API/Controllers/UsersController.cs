using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseAPIController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {

            return Ok(await _userRepository.GetMembersAsync());
        }


        // [HttpGet("{Id}")]
        // public async Task<ActionResult<AppUser>> GetUserById(int Id)
        // {
        //     return await _userRepository.GetUserByIdAsync(Id);
        // }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            return await _userRepository.GetMemberByUserNameAsync(username);
        }

        // [HttpPost("{user}")]
        // public void UpdateUser(AppUser user)
        // {
        //     _userRepository.Update(user);
        // }

        // [HttpPost("{Id}")]
        // public async Task DeleteUser( int Id)
        // {
        //     AppUser userToRemove = _context.Users.Find(Id);
        //     return await _context.Remove();
        // }

    }
}