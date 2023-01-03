using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmaController : ControllerBase
    {
        private readonly DataContext _context;

        public AlarmaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alarma>>> GetAlarmas()
        {
            var alarmas = await _context.Alarmas.Include(p=>p.Pozo).Include(v=>v.VariableProceso)
                
                .ToListAsync();
            return Ok(alarmas);
        }

        [HttpGet("Pozos")]
        public async Task<ActionResult<List<Pozo>>> GetPozos()
        {
            var pozos = await _context.Pozos.ToArrayAsync();
            return Ok(pozos);
        }

        [HttpGet("VariableProceso")]
        public async Task<ActionResult<List<Pozo>>> GetVariableProcesos()
        {
            var variableprocesos = await _context.VariableProcesos.ToArrayAsync();
            return Ok(variableprocesos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Alarma>>> GetSingleAlarma(int id)
        {
            var alarma = await _context.Alarmas.Include(p => p.Pozo).Include(v => v.VariableProceso).FirstOrDefaultAsync(a => a.Id == id);
            if (alarma == null)
            {
                return NotFound("La alarma no ha sido creada :/");
            }

            return Ok(alarma);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Alarma>>> DeleteAlarma(int id)
        {
            var dbAlarma = await _context.Alarmas.Include(p => p.Pozo).Include(v => v.VariableProceso).FirstOrDefaultAsync(a => a.Id == id);
            if (dbAlarma == null)
            {
                return NotFound("La Alarma no existe :/");
            }

            _context.Alarmas.Remove(dbAlarma);
            await _context.SaveChangesAsync();

            return Ok(await GetDbAlarma());
        }

        [HttpPost]

        public async Task<ActionResult<Alarma>> CreateAlarma(Alarma alarma)
        {

            _context.Alarmas.Add(alarma);
            await _context.SaveChangesAsync();
            return Ok(await GetDbAlarma());
        }


        private async Task<List<Alarma>> GetDbAlarma()
        {
            return await _context.Alarmas.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Alarma>>> UpdateAlarma(Alarma alarma)
        {

            var DbAlarma = await _context.Alarmas.FindAsync(alarma.Id);
            if (DbAlarma == null)
                return BadRequest("La alarma no se encuentra");
            DbAlarma.VariableProceso = alarma.VariableProceso;
            DbAlarma.Pozo = alarma.Pozo;
            DbAlarma.PozoId = alarma.PozoId;
            DbAlarma.VariableProcesoId = alarma.VariableProcesoId;
            DbAlarma.Habilitado = alarma.Habilitado;
            DbAlarma.Max=alarma.Max;
            DbAlarma.Min=alarma.Min;

            await _context.SaveChangesAsync();

            return Ok(await _context.Alarmas.ToListAsync());
                  
            

        }
    }
}
