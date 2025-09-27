using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService ) 
        {
            this.categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(categoryService.GetAll());
        
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        {
             var category = categoryService.GetById(id);
                if(category is null)
                {
                    return NotFound();
                }
                return Ok(category);
        }
        [HttpPost("")]
        public IActionResult Create([FromBody] CategoeyRequest request)
        {
           var id = categoryService.Create(request);
            return CreatedAtAction(nameof(Get), new { id } , new {message="ok"});
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute]int id , [FromBody] CategoeyRequest request)
        {
            var updated = categoryService.Update(id, request);
            return updated > 0 ? Ok(updated) : NotFound();
        }
        [HttpPatch("/ToggleStatus/{id}")]
        public IActionResult UpdateToggle([FromRoute] int id)
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok(new {message = "status toggled"}) : NotFound(new {message="Category Not Found"});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = categoryService.Delete(id);
            return deleted > 0 ? Ok(deleted) : NotFound();
        }
    }
}
