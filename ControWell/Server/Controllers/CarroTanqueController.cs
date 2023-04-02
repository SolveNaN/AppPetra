using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroTanqueController : ControllerBase
    {

        private readonly DataContext _context;

        public CarroTanqueController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarroTanque>>> GetCarroTanque()
        {
            var carroTanque = await _context.CarroTanques.ToListAsync();
            return Ok(carroTanque);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<CarroTanque>>> GetSingleCarroTanque(int id)
        {
            var carroTanque = await _context.CarroTanques.FirstOrDefaultAsync(p => p.Id == id);
            if (carroTanque == null)
            {
                return NotFound("La carroTanque de proceso no ha sido creada :/");
            }

            return Ok(carroTanque);
        }

        [HttpPost]

        public async Task<ActionResult<CarroTanque>> CreateCarroTanque(CarroTanque carroTanque)
        {

            _context.CarroTanques.Add(carroTanque);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCarroTanque());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<CarroTanque>>> UpdateCarroTanque(CarroTanque carroTanque)
        {

            var DbCarroTanque = await _context.CarroTanques.FindAsync(carroTanque.Id);
            if (DbCarroTanque == null)
                return BadRequest("La carroTanque no se encuentra");
            DbCarroTanque.TipoVehiculo = carroTanque.TipoVehiculo;
            DbCarroTanque.Capacidad = carroTanque.Capacidad;
            DbCarroTanque.Estado = carroTanque.Estado;

            await _context.SaveChangesAsync();

            return Ok(await _context.CarroTanques.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<CarroTanque>>> DeleteCarroTanque(int id)
        {
            var DbCarroTanque = await _context.CarroTanques.FirstOrDefaultAsync(v => v.Id == id);
            if (DbCarroTanque == null)
            {
                return NotFound("La carroTanque no existe :/");
            }

            _context.CarroTanques.Remove(DbCarroTanque);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCarroTanque());
        }


        private async Task<List<CarroTanque>> GetDbCarroTanque()
        {
            return await _context.CarroTanques.ToListAsync();
        }
    }
}