using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AforoController : ControllerBase
    {
        private readonly DataContext _context;

        public AforoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AforoTK>>> GetAforos()
        {
            var aforos = await _context.AforoTKs.Include(t => t.Tanque)

                .ToListAsync();
            return Ok(aforos);
        }

        [HttpGet("Tanques")]
        public async Task<ActionResult<List<Tanque>>> GetTanque()
        {
            var tanques = await _context.Tanques.ToArrayAsync();
            return Ok(tanques);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<AforoTK>>> GetSingleAforo(int id)
        {
            var aforo = await _context.AforoTKs.Include(t => t.Tanque).FirstOrDefaultAsync(a => a.Id == id);
            if (aforo == null)
            {
                return NotFound("El aforo no fue encontrado :/");
            }

            return Ok(aforo);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<AforoTK>>> DeleteAforo(int id)
        {
            var dbAforo = await _context.AforoTKs.Include(t => t.Tanque).FirstOrDefaultAsync(a => a.Id == id);
            if (dbAforo == null)
            {
                return NotFound("El aforo no existe :/");
            }

            _context.AforoTKs.Remove(dbAforo);
            await _context.SaveChangesAsync();

            return Ok(await GetDbAforo());
        }

        [HttpPost]

        public async Task<ActionResult<AforoTK>> CreateAforo(AforoTK aforo)
        {

            _context.AforoTKs.Add(aforo);
            await _context.SaveChangesAsync();
            return Ok(await GetDbAforo());
        }

        private async Task<List<AforoTK>> GetDbAforo()
        {
            return await _context.AforoTKs.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<AforoTK>>> UpdateAforo(AforoTK aforo)
        {

            var DbAforo = await _context.AforoTKs.FindAsync(aforo.Id);
            if (DbAforo == null)
                return BadRequest("El Aforo no se encuentra");
            DbAforo.Id = aforo.Id;
            DbAforo.TanqueId = aforo.TanqueId;
            DbAforo.Nivel = aforo.Nivel;
            DbAforo.Volunen = aforo.Volunen;
            DbAforo.TempBase = aforo.TempBase;
            DbAforo.Material = aforo.Material;




            await _context.SaveChangesAsync();

            return Ok(await _context.AforoTKs.ToListAsync());

        }





    }
}
