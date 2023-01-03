using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariableProcesoController : ControllerBase
    {
        private readonly DataContext _context;

        public VariableProcesoController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VariableProceso>>> GetVariableProceso()
        {
            var variable = await _context.VariableProcesos.ToListAsync();
            return Ok(variable);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<VariableProceso>>> GetSingleVariableProceso(int id)
        {
            var variable = await _context.VariableProcesos.FirstOrDefaultAsync(v => v.Id == id);
            if (variable == null)
            {
                return NotFound("La variable de proceso no ha sido creada :/");
            }

            return Ok(variable);
        }

        [HttpPost]

        public async Task<ActionResult<VariableProceso>> CreateVariableProceso(VariableProceso variable)
        {
            
            _context.VariableProcesos.Add(variable);
            await _context.SaveChangesAsync();
            return Ok(await GetDbVariableProceso());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<VariableProceso>>> UpdateVariableProceso(VariableProceso variable)
        {

            var DbVariable = await _context.VariableProcesos.FindAsync(variable.Id);
            if(DbVariable==null)
                      return  BadRequest("La variable no se encuentra");
            DbVariable.Nombre = variable.Nombre;
            DbVariable.Unidad= variable.Unidad;

            await _context.SaveChangesAsync();

            return Ok(await _context.VariableProcesos.ToListAsync());
            

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<VariableProceso>>> DeleteVariableProceso(int id)
        {
            var dbVariable = await _context.VariableProcesos.FirstOrDefaultAsync(v => v.Id == id);
            if (dbVariable == null)
            {
                return NotFound("La variable no existe :/");
            }

            _context.VariableProcesos.Remove(dbVariable);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVariableProceso());
        }


        private async Task<List<VariableProceso>> GetDbVariableProceso()
        {
            return await _context.VariableProcesos.ToListAsync();
        }
    }
}
