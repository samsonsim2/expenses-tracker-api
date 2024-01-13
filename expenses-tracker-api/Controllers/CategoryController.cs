using AutoMapper;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using expenses_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace expenses_tracker_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType(200,Type= typeof(IEnumerable<Category>))]  
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.CategoriesExists(id))
            {
                return NotFound();  
            }

            var category = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) {
                return BadRequest(ModelState);
            }

            var category =_categoryRepository.GetCategories().Where(c=>c.Name.Trim().ToUpper() == categoryDTO.Name.Trim().ToUpper()).FirstOrDefault();  

            if(category != null) {
                ModelState.AddModelError("", "Category Already Exists");
                return StatusCode(402, ModelState);
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryMap = _mapper.Map<Category>(categoryDTO);

            if(!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");



        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCategory(int id,[FromBody] CategoryDTO categoryDTO)
        {

            if (categoryDTO == null)
            {
                return BadRequest();
            }

            if (id != categoryDTO.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_categoryRepository.CategoriesExists(id)) {
                return NotFound();

            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var categoryMap = _mapper.Map<Category> (categoryDTO);

            if(!_categoryRepository.UpdateCategory(categoryMap) ){

                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);


            }

            return NoContent(); 

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCategory(int id) {
            
            if(!_categoryRepository.CategoriesExists(id))
            {
                return NotFound();  
            }

            var categoryToDelete = _categoryRepository.GetCategory(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_categoryRepository.DeleteCategory(categoryToDelete)) {

                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent(); 


        }



    }
}