using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using L01_2022CI650_2022VS601.Models;
using L01_2022CI650_2022VS601.Data;

namespace L01_2022CI650_2022VS601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PlatosController(RestauranteDbContext context)
        {
            _context = context;
        }

        // Obtener todos los platos
        [HttpGet]
        public async Task<IActionResult> GetPlatos()
        {
            return Ok(await _context.Platos.ToListAsync());
        }

        // Obtener plato por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
                return NotFound();
            return Ok(plato);
        }

        // Crear plato
        [HttpPost]
        public async Task<IActionResult> CreatePlato(Platos plato)
        {
            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlato), new { id = plato.platoId }, plato);
        }

        // Actualizar plato
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlato(int id, Platos plato)
        {
            if (id != plato.platoId)
                return BadRequest();

            _context.Entry(plato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar plato
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
                return NotFound();

            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Filtrar platos por nombre
        [HttpGet("filtrar/{nombre}")]
        public async Task<IActionResult> FiltrarPlatos(string nombre)
        {
            var platos = await _context.Platos
                .Where(p => p.nombrePlato.Contains(nombre))
                .ToListAsync();
            return Ok(platos);
        }
    }
}
