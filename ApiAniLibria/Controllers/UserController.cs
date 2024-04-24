using Application.Services;
using AutoMapper;
using Contracts.Requests.User;
using Contracts.Responses.User;
using Domain.Entities;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<Domain.Entities.User> _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseService<Domain.Entities.User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
            await _userService.CreateAsync(user, cancellationToken);

            var response = _mapper.Map<UserResponse>(user);
            return CreatedAtAction(nameof(GetUserById), new { id = response.ActivityId }, response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAsync(id, cancellationToken);
            if (user == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<UserResponse>(user);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync(cancellationToken);
            var response = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _userService.GetAsync(id, cancellationToken);
            if (existingUser == null)
            {
                return NotFound();
            }

            var updatedUser = _mapper.Map(request, existingUser);
            await _userService.UpdateAsync(updatedUser, cancellationToken);

            var response = _mapper.Map<UserResponse>(updatedUser);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var deleted = await _userService.DeleteAsync(id, cancellationToken);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

    internal record NewRecord(object Id);
}
