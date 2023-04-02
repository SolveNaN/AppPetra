using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoMovimientoController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoMovimiento>>> GetTipoMovimiento()
        {
            var movimiento = await _context.TipoMovimientos.ToListAsync();
            return Ok(movimiento);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<TipoMovimiento>>> GetSingleTipoMovimiento(int id)
        {
            var movimiento = await _context.TipoMovimientos.FirstOrDefaultAsync(p => p.Id == id);
            if (movimiento == null)
            {
                return NotFound("El movimiento no ha sido creado :/");
            }

            return Ok(movimiento);
        }

        [HttpPost]

        public async Task<ActionResult<TipoMovimiento>> CreateTipoMovimiento(TipoMovimiento movimiento)
        {

            _context.TipoMovimientos.Add(movimiento);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTipoMovimiento());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TipoMovimiento>>> UpdateTipoMovimiento(TipoMovimiento movimiento)
        {

            var DbTipoMovimiento = await _context.TipoMovimientos.FindAsync(movimiento.Id);
            if (DbTipoMovimiento == null)
                return BadRequest("El Tipo de Movimiento no se encuentra");
            DbTipoMovimiento.NombreMovimiento = movimiento.NombreMovimiento;
  

            await _context.SaveChangesAsync();

            return Ok(await _context.TipoMovimientos.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<TipoMovimiento>>> DeleteTipoMovimiento(int id)
        {
            var DbTipoMovimiento = await _context.TipoMovimientos.FirstOrDefaultAsync(v => v.Id == id);
            if (DbTipoMovimiento == null)
            {
                return NotFound("El Tipo de movimiento no existe :/");
            }

            _context.TipoMovimientos.Remove(DbTipoMovimiento);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTipoMovimiento());
        }


        private async Task<List<TipoMovimiento>> GetDbTipoMovimiento()
        {
            return await _context.TipoMovimientos.ToListAsync();
        }
    }
}
