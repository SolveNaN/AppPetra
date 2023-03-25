using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {

        private readonly DataContext _context;

        public DestinoController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Destino>>> GetDestino()
        {
            var Destino = await _context.Destinos.ToListAsync();
            return Ok(Destino);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Destino>>> GetSingleDestino(int id)
        {
            var Destino = await _context.Destinos.FirstOrDefaultAsync(p => p.Id == id);
            if (Destino == null)
            {
                return NotFound("La Destino de proceso no ha sido creada :/");
            }

            return Ok(Destino);
        }

        [HttpPost]

        public async Task<ActionResult<Destino>> CreateDestino(Destino Destino)
        {

            _context.Destinos.Add(Destino);
            await _context.SaveChangesAsync();
            return Ok(await GetDbDestino());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Destino>>> UpdateDestino(Destino Destino)
        {

            var DbDestino = await _context.Destinos.FindAsync(Destino.Id);
            if (DbDestino == null)
                return BadRequest("La Destino no se encuentra");
            //DbDestino.NombreDestino = Destino.NombreDestino;
            //DbDestino.Ubicacion = Destino.Ubicacion;
            //DbDestino.Operadora = Destino.Operadora;
            //DbDestino.Comentario = Destino.Comentario;

            await _context.SaveChangesAsync();

            return Ok(await _context.Destinos.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Destino>>> DeleteDestino(int id)
        {
            var DbDestino = await _context.Destinos.FirstOrDefaultAsync(v => v.Id == id);
            if (DbDestino == null)
            {
                return NotFound("La Destino no existe :/");
            }

            _context.Destinos.Remove(DbDestino);
            await _context.SaveChangesAsync();

            return Ok(await GetDbDestino());
        }


        private async Task<List<Destino>> GetDbDestino()
        {
            return await _context.Destinos.ToListAsync();
        }
    }
}