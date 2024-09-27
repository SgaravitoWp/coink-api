using Microsoft.AspNetCore.Mvc;
using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.DTOs;
using CoinkRestAPI.CORE.Interfaces;
using Npgsql;

namespace CoinRestAPI.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType(typeof(SuccessResponse<User>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserPost userDto)
        {
            string message;
            try
            {
                var createdUser = await _userService.CreateUserAsync(userDto);
                message = "User Created";
                return CreatedAtAction(nameof(CreateUser), new SuccessResponse<User>
                {
                    success = true,
                    message = message,
                    data = new List<User> { createdUser },
                    status_code = 201
                });
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") // Código de error para violación de clave única
            {
                message = "User already registered.";
            }
            catch (PostgresException ex) when (ex.SqlState == "40000") // Código de error personalizado para la no correspondencia de locaciones. 
            {
                message = "Invalid data insertion. Verify that the location identifiers match";
            }

            return BadRequest(new ErrorResponse
            {
                success = false,
                title = message,
                status = 400
            });

        }
    }
}