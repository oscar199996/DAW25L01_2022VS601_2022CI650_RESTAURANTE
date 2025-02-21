using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using L01_2022CI650_2022VS601.Models;

namespace L01_2022CI650_2022VS601.Controllers
{
    public class PedidosController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PedidosController : ControllerBase
        {
            private readonly RestauranteDbContext _context;

            public PedidosController(RestauranteDbContext context)
            {
                _context = context;
            }

            // Obtener todos los pedidos
            [HttpGet]
            public async Task<IActionResult> GetPedidos()
            {
                return Ok(await _context.Pedidos.ToListAsync());
            }

            // Obtener pedido por ID
            [HttpGet("{id}")]
            public async Task<IActionResult> GetPedido(int id)
            {
                var pedido = await _context.Pedidos.FindAsync(id);
                if (pedido == null)
                    return NotFound();
                return Ok(pedido);
            }

            // Crear pedido
            [HttpPost]
            public async Task<IActionResult> CreatePedido(Pedidos pedido)
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPedido), new { id = pedido.PedidoId }, pedido);
            }

            // Actualizar pedido
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePedido(int id, Pedidos pedido)
            {
                if (id != pedido.PedidoId)
                    return BadRequest();

                _context.Entry(pedido).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            // Eliminar pedido
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePedido(int id)
            {
                var pedido = await _context.Pedidos.FindAsync(id);
                if (pedido == null)
                    return NotFound();

                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            // Filtrar pedidos por cliente
            [HttpGet("cliente/{clienteId}")]
            public async Task<IActionResult> FiltrarPedidosPorCliente(int clienteId)
            {
                var pedidos = await _context.Pedidos.Where(p => p.ClienteId == clienteId).ToListAsync();
                return Ok(pedidos);
            }

            // Filtrar pedidos por motorista
            [HttpGet("motorista/{motoristaId}")]
            public async Task<IActionResult> FiltrarPedidosPorMotorista(int motoristaId)
            {
                var pedidos = await _context.Pedidos.Where(p => p.MotoristaId == motoristaId).ToListAsync();
                return Ok(pedidos);
            }
        }
    }
}
