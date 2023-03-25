using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperarioController : ControllerBase
    {

        private readonly DataContext _context;

        public OperarioController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operario>>> GetOperario()
        {
            var Operario = await _context.Operarios.ToListAsync();
            return Ok(Operario);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Operario>>> GetSingleOperario(int id)
        {
            var Operario = await _context.Operarios.FirstOrDefaultAsync(p => p.Id == id);
            if (Operario == null)
            {
                return NotFound("La Operario de proceso no ha sido creada :/");
            }

            return Ok(Operario);
        }

        [HttpPost]

        public async Task<ActionResult<Operario>> CreateOperario(Operario Operario)
        {

            _context.Operarios.Add(Operario);
            await _context.SaveChangesAsync();
            return Ok(await GetDbOperario());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Operario>>> UpdateOperario(Operario Operario)
        {

            var DbOperario = await _context.Operarios.FindAsync(Operario.Id);
            if (DbOperario == null)
                return BadRequest("La Operario no se encuentra");
            //DbOperario.NombreOperario = Operario.NombreOperario;
            //DbOperario.Ubicacion = Operario.Ubicacion;
            //DbOperario.Operadora = Operario.Operadora;
            //DbOperario.Comentario = Operario.Comentario;

            await _context.SaveChangesAsync();

            return Ok(await _context.Operarios.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Operario>>> DeleteOperario(int id)
        {
            var DbOperario = await _context.Operarios.FirstOrDefaultAsync(v => v.Id == id);
            if (DbOperario == null)
            {
                return NotFound("La Operario no existe :/");
            }

            _context.Operarios.Remove(DbOperario);
            await _context.SaveChangesAsync();

            return Ok(await GetDbOperario());
        }


        private async Task<List<Operario>> GetDbOperario()
        {
            return await _context.Operarios.ToListAsync();
        }
    }
}