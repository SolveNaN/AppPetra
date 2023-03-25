using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaDiariaController : ControllerBase
    {

        private readonly DataContext _context;

        public OfertaDiariaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfertaDiaria>>> GetOfertaDiaria()
        {
            var ofertaDiaria = await _context.OfertaDiariaProgramacionCarrotanques.ToListAsync();
            return Ok(ofertaDiaria);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<OfertaDiaria>>> GetSingleOfertaDiaria(int id)
        {
            var ofertaDiaria = await _context.OfertaDiariaProgramacionCarrotanques.FirstOrDefaultAsync(p => p.Id == id);
            if (ofertaDiaria == null)
            {
                return NotFound("La OfertaDiaria de proceso no ha sido creada :/");
            }

            return Ok(ofertaDiaria);
        }

        [HttpGet]
        [Route("/{placa}")]
        public async Task<ActionResult<List<OfertaDiaria>>> GetByPlacaOfertaDiaria(string placa)
        {
            Console.WriteLine($"placa que envia el front {placa}");
            var ofertaDiariaPlaca = await _context.OfertaDiariaProgramacionCarrotanques.FirstOrDefaultAsync(p => p.Placa == placa);
            //if (ofertaDiariaPlaca == null)
            //{
            //    return NotFound("Placa no encontrada :/");
            //}

               Console.WriteLine($"ofertadiariaplaca {ofertaDiariaPlaca}");
              return Ok(ofertaDiariaPlaca);
        }

        [HttpPost]

        public async Task<ActionResult<OfertaDiaria>> CreateOfertaDiaria(OfertaDiaria ofertaDiaria)
        {

            _context.OfertaDiariaProgramacionCarrotanques.Add(ofertaDiaria);
            await _context.SaveChangesAsync();
            return Ok(await GetDbOfertaDiaria());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OfertaDiaria>>> UpdateOfertaDiaria(OfertaDiaria ofertaDiaria)
        {

            var DbofertaDiaria = await _context.OfertaDiariaProgramacionCarrotanques.FindAsync(ofertaDiaria.Id);
            if (DbofertaDiaria == null)
                return BadRequest("La OfertaDiaria no se encuentra");
            DbofertaDiaria.EmpresaTransportadora = ofertaDiaria.EmpresaTransportadora;
            DbofertaDiaria.Placa = ofertaDiaria.Placa;
            DbofertaDiaria.Tanque = ofertaDiaria.Tanque;
            DbofertaDiaria.NombreConductor = ofertaDiaria.NombreConductor;
            DbofertaDiaria.Cedula = ofertaDiaria.Cedula;
            DbofertaDiaria.CodigoRuta = ofertaDiaria.CodigoRuta;
            DbofertaDiaria.Origen = ofertaDiaria.Origen;
            DbofertaDiaria.Destino = ofertaDiaria.Destino;
            DbofertaDiaria.Observacion = ofertaDiaria.Observacion;
            DbofertaDiaria.CreatedAt = ofertaDiaria.CreatedAt;
            DbofertaDiaria.FechaCreacion = ofertaDiaria.FechaCreacion;
            DbofertaDiaria.disponible = ofertaDiaria.disponible;

            await _context.SaveChangesAsync();

            return Ok(await _context.OfertaDiariaProgramacionCarrotanques.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<OfertaDiaria>>> DeleteOfertaDiaria(int id)
        {
            var DbofertaDiaria = await _context.OfertaDiariaProgramacionCarrotanques.FirstOrDefaultAsync(v => v.Id == id);
            if (DbofertaDiaria == null)
            {
                return NotFound("La OfertaDiaria no existe :/");
            }

            _context.OfertaDiariaProgramacionCarrotanques.Remove(DbofertaDiaria);
            await _context.SaveChangesAsync();

            return Ok(await GetDbOfertaDiaria());
        }

        private async Task<List<OfertaDiaria>> GetDbOfertaDiaria()
        {
            return await _context.OfertaDiariaProgramacionCarrotanques.ToListAsync();
        }
    }
}