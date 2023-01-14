﻿using ClosedXML.Excel;
using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Data;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly DataContext _context;

        public RegistroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registro>>> GetRegistros()
        {
            var registros = await _context.Registros.Include(p => p.Pozo).Include(v => v.VariableProceso)

                .ToListAsync();
            IEnumerable<Registro> RegistrosOrdenados = from reg in _context.Registros//Creo una lista ordenada por fecha
                                                       orderby reg.FechaHora descending
                                                       select reg;
            return Ok(RegistrosOrdenados);
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
        public async Task<ActionResult<List<Registro>>> GetSingleRegistro(int id)
        {
            var registro = await _context.Registros.Include(p => p.Pozo).Include(v => v.VariableProceso).FirstOrDefaultAsync(r => r.Id == id);
            if (registro == null)
            {
                return NotFound("El Registro no ha sido creada :/");
            }

            return Ok(registro);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Registro>>> DeleteRegistro(int id)
        {
            var dbRegistro = await _context.Registros.Include(p => p.Pozo).Include(v => v.VariableProceso).FirstOrDefaultAsync(r => r.Id == id);
            if (dbRegistro == null)
            {
                return NotFound("La Registro no existe :/");
            }

            _context.Registros.Remove(dbRegistro);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRegistro());
        }

        [HttpPost]

        public async Task<ActionResult<Registro>> CreateRegistro(Registro registro)
        {

            _context.Registros.Add(registro);
            await _context.SaveChangesAsync();
            return Ok(await GetDbRegistro());
        }

        private async Task<List<Registro>> GetDbRegistro()
        {
            return await _context.Registros.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Registro>>> UpdateRegistro(Registro registro)
        {

            var DbRegistro = await _context.Registros.FindAsync(registro.Id);
            if (DbRegistro == null)
                return BadRequest("El Registro no se encuentra");
            DbRegistro.Id = registro.Id;
            DbRegistro.FechaHora = registro.FechaHora;
            DbRegistro.Pozo = registro.Pozo;
            DbRegistro.PozoId = registro.PozoId;
            DbRegistro.VariableProceso = registro.VariableProceso;
            DbRegistro.VariableProcesoId = registro.VariableProcesoId;
            DbRegistro.Medida = registro.Medida;

            await _context.SaveChangesAsync();

            return Ok(await _context.Registros.ToListAsync());

        }

  

    }
}
