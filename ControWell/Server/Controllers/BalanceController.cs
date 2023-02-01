using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly DataContext _context;

        public BalanceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Balance>>> GetBalances()
        {
            var balance = await _context.Balances.Include(t => t.Tanque).Include(p => p.Pozo).Include(m => m.Movimiento)

                .ToListAsync();

            return Ok(balance);
        }

        [HttpGet("Pozos")]
        public async Task<ActionResult<List<Pozo>>> GetPozos()
        {
            var pozos = await _context.Pozos.ToArrayAsync();
            return Ok(pozos);
        }

        [HttpGet("Tanques")]
        public async Task<ActionResult<List<Tanque>>> GetTanque()
        {
            var mitanque = await _context.Tanques.ToArrayAsync();
            return Ok(mitanque);
        }
        [HttpGet("Movimiento")]
        public async Task<ActionResult<List<TipoMovimiento>>> GetTipoMovimiento()
        {
            var miMovimiento = await _context.Movimientos.ToArrayAsync();
            return Ok(miMovimiento);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Balance>>> GetSingleBalance(int id)
        {
            var miBalance = await _context.Balances.Include(t => t.Tanque).Include(p => p.Pozo).Include(m => m.Movimiento).FirstOrDefaultAsync(tm => tm.Id == id);
            if (miBalance == null)
            {
                return NotFound("El Balance no ha sido creada :/");
            }

            return Ok(miBalance);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Balance>>> DeleteBalance(int id)
        {
            var dbBalance = await _context.Balances.Include(t => t.Tanque).Include(p => p.Pozo).Include(m => m.Movimiento).FirstOrDefaultAsync(r => r.Id == id);
            if (dbBalance == null)
            {
                return NotFound("La Balance no existe :/");
            }

            _context.Balances.Remove(dbBalance);
            await _context.SaveChangesAsync();

            return Ok(await GetDbBalance());
        }

        [HttpPost]

        public async Task<ActionResult<Balance>> CreateBalance(Balance miBalance)
        {

            _context.Balances.Add(miBalance);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBalance());
        }

        private async Task<List<Balance>> GetDbBalance()
        {
            return await _context.Balances.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Balance>>> UpdateBalance(Balance miBalance)
        {

            var DbBalance = await _context.Balances.FindAsync(miBalance.Id);
            if (DbBalance == null)
                return BadRequest("El Balance no se encuentra");
            DbBalance.Id = miBalance.Id;


            await _context.SaveChangesAsync();

            return Ok(await _context.Balances.ToListAsync());

        }
    }
}
