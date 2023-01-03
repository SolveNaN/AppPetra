using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozoController : ControllerBase
    {

        private readonly DataContext _context;

        public PozoController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pozo>>> GetPozo()
        {
            var pozo = await _context.Pozos.ToListAsync();
            return Ok(pozo);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Pozo>>> GetSinglePozo(int id)
        {
            var pozo = await _context.Pozos.FirstOrDefaultAsync(p => p.Id == id);
            if (pozo == null)
            {
                return NotFound("La pozo de proceso no ha sido creada :/");
            }

            return Ok(pozo);
        }

        [HttpPost]

        public async Task<ActionResult<Pozo>> CreatePozo(Pozo pozo)
        {

            _context.Pozos.Add(pozo);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPozo());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Pozo>>> UpdatePozo(Pozo pozo)
        {

            var DbPozo = await _context.Pozos.FindAsync(pozo.Id);
            if (DbPozo == null)
                return BadRequest("La pozo no se encuentra");
            DbPozo.NombrePozo = pozo.NombrePozo;
            DbPozo.Ubicacion = pozo.Ubicacion;
            DbPozo.Operadora = pozo.Operadora;
            DbPozo.Comentario = pozo.Comentario;

            await _context.SaveChangesAsync();

            return Ok(await _context.Pozos.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Pozo>>> DeletePozo(int id)
        {
            var DbPozo = await _context.Pozos.FirstOrDefaultAsync(v => v.Id == id);
            if (DbPozo == null)
            {
                return NotFound("La pozo no existe :/");
            }

            _context.Pozos.Remove(DbPozo);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPozo());
        }


        private async Task<List<Pozo>> GetDbPozo()
        {
            return await _context.Pozos.ToListAsync();
        }
    }
}