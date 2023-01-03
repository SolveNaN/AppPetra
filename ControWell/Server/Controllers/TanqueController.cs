using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanqueController : ControllerBase
    {

        private readonly DataContext _context;

        public TanqueController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tanque>>> GetTanque()
        {
            var tanque = await _context.Tanques.ToListAsync();
            return Ok(tanque);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Tanque>>> GetSingleTanque(int id)
        {
            var tanque = await _context.Tanques.FirstOrDefaultAsync(t => t.Id == id);
            if (tanque == null)
            {
                return NotFound("El tanque no fue encontrado :/");
            }

            return Ok(tanque);
        }

        [HttpPost]

        public async Task<ActionResult<Tanque>> CreateTanque(Tanque tanque)
        {

            _context.Tanques.Add(tanque);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTanque());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Tanque>>> UpdateTanque(Tanque tanque)
        {

            var DbTanque = await _context.Tanques.FindAsync(tanque.Id);
            if (DbTanque == null)
                return BadRequest("El tanque no se encuentra");
            DbTanque.NombreTanque = tanque.NombreTanque;
            DbTanque.Capacidad = tanque.Capacidad;
            DbTanque.TipoFluido = tanque.TipoFluido;

            await _context.SaveChangesAsync();

            return Ok(await _context.Tanques.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Tanque>>> DeleteTanque(int id)
        {
            var DbTanque = await _context.Tanques.FirstOrDefaultAsync(t => t.Id == id);
            if (DbTanque == null)
            {
                return NotFound("El tanque no exisate :/");
            }

            _context.Tanques.Remove(DbTanque);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTanque());
        }


        private async Task<List<Tanque>> GetDbTanque()
        {
            return await _context.Tanques.ToListAsync();
        }
    }
}