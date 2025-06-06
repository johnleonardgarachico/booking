using Microsoft.AspNetCore.Mvc;
using TripBooking.Domain.Client.Api;
using TripBooking.Infrastructure.Database;

namespace TripBooking.ServiceHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(ILogger<UsersController> logger,
                                 UsersRepository usersRepository)
        : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly UsersRepository _usersRepository = usersRepository;

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUserAsync([FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            if (request is null) return BadRequest("Invalid request data.");

            var result = await _usersRepository.AddUserAsync(request.FirstName, request.LastName,
                request.BirthDate, request.Username, request.Password, cancellationToken);

            if (result is null) return StatusCode(500, "Something went wrong. boo!");

            return Ok(new { UserId = result });

        }
    }
}
