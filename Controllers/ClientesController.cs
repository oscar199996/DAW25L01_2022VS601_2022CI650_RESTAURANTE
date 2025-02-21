using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using L01_2022CI650_2022VS601.Models;

namespace L01_2022CI650_2022VS601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public ClientesController(RestauranteDbContext context)
        {
            _context = context;
        }

        // Obtener todos los clientes
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        // Obtener cliente por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        // Crear cliente
        [HttpPost]
        public async Task<IActionResult> CreateCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
        }

        // Actualizar cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Clientes cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Filtrar clientes por dirección
        [HttpGet("filtrar/{direccion}")]
        public async Task<IActionResult> FiltrarClientes(string direccion)
        {
            var clientes = await _context.Clientes
                .Where(c => c.Direccion.Contains(direccion))
                .ToListAsync();
            return Ok(clientes);
        }
    }
}