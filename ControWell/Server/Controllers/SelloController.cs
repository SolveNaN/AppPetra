using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelloController : ControllerBase
    {
        private readonly DataContext _context;

        public SelloController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sello>>> GetSello()
        {
            var sellos = await _context.Sellos.ToListAsync();
            return Ok(sellos);
        }

        [HttpPost]
        public async Task<ActionResult<Sello>> CreateSello(Sello sello)
        {

            _context.Sellos.Add(sello);
            await _context.SaveChangesAsync();
            return Ok(await GetDbSello());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sello>>> UpdateSello(Sello sello)
        {
            var DbSello = await _context.Sellos.FindAsync(sello.Id);
            if (DbSello == null)
                return BadRequest("EL sello no se encuentra");
            DbSello.NumeroSello = sello.NumeroSello;
            DbSello.IndiceSello = sello.IndiceSello;
            DbSello.Lote = sello.Lote;
            DbSello.Estado = sello.Estado;
            DbSello.CreatedAt = sello.CreatedAt;

            await _context.SaveChangesAsync();

            return Ok(await _context.Sellos.ToListAsync());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Sello>>> DeleteSello(int id)
        {
            var DbSello = await _context.Sellos.FirstOrDefaultAsync(v => v.Id == id);
            if (DbSello == null)
            {
                return NotFound("La Sello no existe :/");
            }

            _context.Sellos.Remove(DbSello);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSello());
        }


        private async Task<List<Sello>> GetDbSello()
        {
            return await _context.Sellos.ToListAsync();
        }
    }
}