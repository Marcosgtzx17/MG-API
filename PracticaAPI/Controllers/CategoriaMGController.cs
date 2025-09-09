using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaAPI.DTOs.CategoriaDTOs;
using PracticaAPI.Interfaces;

namespace PracticaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 todos los endpoints requieren login
    public class CategoriaMGController : ControllerBase
    {
        private readonly ICategoriaMGService _service;

        public CategoriaMGController(ICategoriaMGService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaMGDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaMGDto>> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaMGDto>> Create(CategoriaMGCreateDto dto)
        {
            var categoria = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaMGDto>> Update(int id, CategoriaMGCreateDto dto)
        {
            var categoria = await _service.UpdateAsync(id, dto);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
