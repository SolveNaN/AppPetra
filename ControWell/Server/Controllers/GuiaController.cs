using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiaController : ControllerBase
    {
        private readonly DataContext _context;

        public GuiaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Guia>>> GetGuia()
        {
            var guia = await _context.Guias.ToListAsync();
            return Ok(guia);
        }   

        [HttpPost]
        public async Task<ActionResult<Guia>> CreateGuia(Guia guia)
        {
            IEnumerable<Guia> GuiasConsultadas = from guiaD in _context.Guias
                                                 where guiaD.NumeroGuia == guia.NumeroGuia
                                                 select guiaD;

            Console.WriteLine("guias consultadas:", GuiasConsultadas);
            Console.WriteLine("guias recibida desde el front:", guia.NumeroGuia);

            _context.Guias.Add(guia);
            await _context.SaveChangesAsync();
            return Ok(await GetDbGuia());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Guia>>> UpdateGuia(Guia guia)
        {
            var DbGuia = await _context.Guias.FindAsync(guia.Id);
            if (DbGuia == null)
                return BadRequest("La guia no se encuentra");
            DbGuia.NumeroGuia = guia.NumeroGuia;
            DbGuia.Lote = guia.Lote;
            DbGuia.Estado = guia.Estado;
            DbGuia.CreatedAt = guia.CreatedAt;

            await _context.SaveChangesAsync();

            return Ok(await _context.Guias.ToListAsync());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Guia>>> DeleteGuia(int id)
        {
            var DbGuia = await _context.Guias.FirstOrDefaultAsync(v => v.Id == id);
            if (DbGuia == null)
            {
                return NotFound("La Guia no existe :/");
            }

            _context.Guias.Remove(DbGuia);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGuia());
        }

        private async Task<List<Guia>> GetDbGuia()
        {
            return await _context.Guias.ToListAsync();
        }
    }
}