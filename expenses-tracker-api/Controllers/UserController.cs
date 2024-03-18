using AutoMapper;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using expenses_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace expenses_tracker_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository usersRepository, IMapper mapper)
        {
           _usersRepository = usersRepository;
            _mapper = mapper;
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

        [HttpGet("username")]
        public IActionResult GetUserByUsername(string username)
        {
            return Ok(_usersRepository.GetUserByUsername(username));
        }


        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult FindOrCreateUser([FromBody] UserDTO userDTO)
        {

            var userMap = _mapper.Map<User>(userDTO);

            var user =_usersRepository.FindOrCreateUser(userMap);

            return Ok(user);    

            

        }

    }
}