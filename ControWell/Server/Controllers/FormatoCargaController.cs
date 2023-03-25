using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatoCargaController : ControllerBase
    {

        private readonly DataContext _context;

        public FormatoCargaController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormatoCarga>>> GetFormatoCarga()
        {
            var formatoCarga = await _context.FormatoCarroTanquesCargados.ToListAsync();
            return Ok(formatoCarga);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<FormatoCarga>>> GetSingleFormatoCarga(int id)
        {
            var formatoCarga = await _context.FormatoCarroTanquesCargados.FirstOrDefaultAsync(p => p.Id == id);
            if (formatoCarga == null)
            {
                return NotFound("La formatoCarga de proceso no ha sido creada :/");
            }

            return Ok(formatoCarga);
        }

        [HttpPost]

        public async Task<ActionResult<FormatoCarga>> CreateFormatoCarga(FormatoCarga formatoCarga)
        {

            _context.FormatoCarroTanquesCargados.Add(formatoCarga);
            await _context.SaveChangesAsync();
            return Ok(await GetDbFormatoCarga());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<FormatoCarga>>> UpdateFormatoCarga(FormatoCarga formatoCarga)
        {

            var DbFormatoCarga = await _context.FormatoCarroTanquesCargados.FindAsync(formatoCarga.Id);
            if (DbFormatoCarga == null)
                return BadRequest("La formatoCarga no se encuentra");
            //DbFormatoCarga.NombreFormatoCarga = formatoCarga.NombreFormatoCarga;
            //DbFormatoCarga.Ubicacion = formatoCarga.Ubicacion;
            //DbFormatoCarga.Operadora = formatoCarga.Operadora;
            //DbFormatoCarga.Comentario = formatoCarga.Comentario;

            await _context.SaveChangesAsync();

            return Ok(await _context.FormatoCarroTanquesCargados.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<FormatoCarga>>> DeleteFormatoCarga(int id)
        {
            var DbFormatoCarga = await _context.FormatoCarroTanquesCargados.FirstOrDefaultAsync(v => v.Id == id);
            if (DbFormatoCarga == null)
            {
                return NotFound("La formatoCarga no existe :/");
            }

            _context.FormatoCarroTanquesCargados.Remove(DbFormatoCarga);
            await _context.SaveChangesAsync();

            return Ok(await GetDbFormatoCarga());
        }


        private async Task<List<FormatoCarga>> GetDbFormatoCarga()
        {
            return await _context.FormatoCarroTanquesCargados.ToListAsync();
        }
    }
}