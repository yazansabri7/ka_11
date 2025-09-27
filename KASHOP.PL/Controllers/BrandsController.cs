using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll() => Ok(brandService.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var brand = brandService.GetById(id);
            if (brand is null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpPost("")]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = brandService.Create(request);
            return CreatedAtAction(nameof(Get), new { id }, new { message = "ok" });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = brandService.Update(id, request);
            return updated > 0 ? Ok(updated) : NotFound();
        }
        [HttpPatch("/ToggleStatus/{id}")]
        public IActionResult UpdateToggle([FromRoute] int id)
        {
            var updated = brandService.ToggleStatus(id);
            return updated ? Ok(new { message = "status toggled" }) : NotFound(new { message = "Brand Not Found" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = brandService.Delete(id);
            return deleted > 0 ? Ok(deleted) : NotFound();
        }
    }
}
