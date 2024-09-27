using Npgsql;
using CoinkRestAPI.CORE.DTOs;
using Microsoft.AspNetCore.Mvc;
using CoinkRestAPI.CORE.Entities;
using CoinkRestAPI.CORE.Interfaces;

namespace CoinRestAPI.API.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones relacionadas con usuarios.
    /// </summary>
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary>
        /// <param name="userService">Servicio de usuarios inyectado.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Datos del usuario a crear.</param>
        /// <returns>El usuario creado si la operación es exitosa.</returns>
        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType(typeof(SuccessResponse<User>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserPost user)
        {
            string message;
            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                message = "Usuario Creado";
                return CreatedAtAction(nameof(CreateUser), new SuccessResponse<User>
                {
                    success = true,
                    message = message,
                    data = new List<User> { createdUser },
                    status_code = 201
                });
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") 
            {
                message = "Usuario ya registrado.";
            }
            catch (PostgresException ex) when (ex.SqlState == "40000") 
            {
                message = "Inserción de datos inválida. Verifique que los identificadores de ubicación coincidan.";
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