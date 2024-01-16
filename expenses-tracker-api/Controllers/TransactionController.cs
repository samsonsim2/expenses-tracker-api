using AutoMapper;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using expenses_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace expenses_tracker_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {


        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _usersRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepository transactionRepository, IUserRepository usersRepository, ICategoryRepository categoryRepository,IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _usersRepository = usersRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transaction>))]
        public IActionResult GetTransactions()
        {
            var transactions = _mapper.Map<List<TransactionDTO>>(_transactionRepository.GetTransactions());

            return Ok(transactions);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        public IActionResult GetTransactionsByUser(int id )
        {
            var transactions = _transactionRepository.GetTransactionsByUser(id);

            return Ok(transactions);
        }


        [HttpGet("{transactionId}")]
        [ProducesResponseType(200, Type = typeof(Transaction))]
        public IActionResult GetTransaction(int transactionId)
        {
            var transactions = _transactionRepository.GetTransaction(transactionId);

            return Ok(transactions);
        }


        [HttpPost]
        [ProducesResponseType(204)]

        public IActionResult CreateTransaction([FromQuery] int userId, [FromQuery] int categoryId, [FromBody] TransactionDTO transactionDTO)


        {
            var transactionMap = _mapper.Map<Transaction>(transactionDTO);



            transactionMap.User = _usersRepository.GetUser(userId);
            transactionMap.Category = _categoryRepository.GetCategory(userId);


            if (!_transactionRepository.CreateTransaction(transactionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");

        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReview(int transactionId)
        {
            if (!_transactionRepository.TransactionExists(transactionId))
            {
                return NotFound();
            }

            var transactionToDelete = _transactionRepository.GetTransaction(transactionId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_transactionRepository.DeleteTransaction(transactionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting review");

            }

            return NoContent();

        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTransaction(int id, [FromQuery] int userId, [FromQuery] int categoryId, [FromBody] TransactionDTO transactionDTO)
        {
            var transactionMap = _mapper.Map<Transaction>(transactionDTO);

            transactionMap.User = _usersRepository.GetUser(userId);
            transactionMap.Category = _categoryRepository.GetCategory(userId);

            _transactionRepository.UpdateTransaction(transactionMap);

            return Ok("Successfully Updated");



        }

    }
}
