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

        private async Task<List<Sello>> GetDbSello()
        {
            return await _context.Sellos.ToListAsync();
        }
    }
}