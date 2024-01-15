using expenses_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace expenses_tracker_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
           _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_usersRepository.GetUsers());
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            return Ok(_usersRepository.GetUser(id));
        }

    }
}