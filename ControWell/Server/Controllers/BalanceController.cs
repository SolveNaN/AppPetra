using ClosedXML.Excel;
using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<ActionResult<List<Balance>>> GetBalance()
        {
            var Bal = await _context.Balances.Include(t=>t.Tanque).Include(p => p.Pozo).Include(tm => tm.TipoMovimiento).ToListAsync();
            return Ok(Bal);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Balance>>> GetSingleBalance(int id)
        {
            var Bal = await _context.Balances.Include(t => t.Tanque).Include(p => p.Pozo).Include(tm => tm.TipoMovimiento).FirstOrDefaultAsync(b => b.Id == id);
            if (Bal == null)
            {
                return NotFound("La Balance de proceso no ha sido creada :/");
            }

            return Ok(Bal);
        }

        [HttpPost]

        public async Task<ActionResult<Balance>> CreateBalance(Balance mibalance)
        {

            mibalance.Fecha=DateTime.Now;
            mibalance.Ctsh = 1;
            mibalance.Ctl = 1;
            decimal FRA = 0;
            mibalance.Gov = (mibalance.Tov - mibalance.Fw) * mibalance.Ctsh + FRA;
            mibalance.Gsv = mibalance.Gov;
            mibalance.Nsv = mibalance.Gsv * (1 - (mibalance.Syw/100));
            mibalance.Agua = mibalance.Gsv - mibalance.Nsv;
            _context.Balances.Add(mibalance);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBalance());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Balance>>> UpdateBalance(Balance mibalance)
        {

            var DbBalance = await _context.Balances.FindAsync(mibalance.Id);
            if (DbBalance == null)
                return BadRequest("La pozo no se encuentra");

   

            await _context.SaveChangesAsync();

            return Ok(await _context.Balances.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Balance>>> DeleteBalance(int id)
        {
            var DbBalance = await _context.Balances.FirstOrDefaultAsync(b => b.Id == id);
            if (DbBalance == null)
            {
                return NotFound("La Balance no existe :/");
            }

            _context.Balances.Remove(DbBalance);
            await _context.SaveChangesAsync();

            return Ok(await GetDbBalance());
        }


        private async Task<List<Balance>> GetDbBalance()
        {
            return await _context.Balances.ToListAsync();
        }

        //Metodo exportar excel

        [HttpGet]
        [Route("ExportExcel")]
        public IActionResult ExportExcel()
        {
            List<ViewModelBalance> BalancesOrdenados = (from bal in _context.Balances
                                                          join pozo in _context.Pozos on bal.PozoId equals pozo.Id
                                                          join tanque in _context.Tanques on bal.TanqueId equals tanque.Id
                                                          join movimiento in _context.TipoMovimientos on bal.TipoMovimientoId equals movimiento.Id
                                                          select new ViewModelBalance
                                                          {
                                                              Fecha = bal.Fecha.ToString() ?? "",
                                                              Tanque = tanque.NombreTanque,
                                                              TipoMovimiento=movimiento.NombreMovimiento,
                                                              Pozo = pozo.NombrePozo,                                                              
                                                              Nivel = bal.Nivel.ToString(),
                                                              Interfase= bal.Interfase.ToString(),
                                                              Api= bal.Api.ToString(),
                                                              Syw= bal.Syw.ToString(),
                                                              TemFluido= bal.TemFluido.ToString(),
                                                              TemAmbiente=bal.TemAmbiente.ToString(),
                                                              Tov= bal.Tov.ToString(),
                                                              Fw= bal.Fw.ToString(),
                                                              Ctsh= bal.Ctsh.ToString(),
                                                              Ctl=bal.Ctl.ToString(),
                                                              Gov= bal.Gov.ToString(),
                                                              Gsv= bal.Gsv.ToString(),
                                                              Nsv= bal.Nsv.ToString(),
                                                              Sywbls=bal.Agua.ToString()
                                                          }


                                                          ).ToList();//Creo una lista ordenada por fecha


            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Fecha");
                table.Columns.Add("Tanque");
                table.Columns.Add("Ultimo movimiento");
                table.Columns.Add("Pozo");
                table.Columns.Add("Nivel");
                table.Columns.Add("Interfase");
                table.Columns.Add("API");
                table.Columns.Add("SyW");
                table.Columns.Add("Temp Fluido °F");
                table.Columns.Add("Temp ambiente °F");
                table.Columns.Add("TOV");
                table.Columns.Add("FW");
                table.Columns.Add("CTSh");
                table.Columns.Add("CTL");
                table.Columns.Add("GOV");
                table.Columns.Add("GSV");
                table.Columns.Add("NSV");
                table.Columns.Add("SyW(Bls)");

                foreach (var item in BalancesOrdenados)
                {
                    DataRow fila = table.NewRow();
                    fila["Fecha"] = item.Fecha;
                    fila["Tanque"] = item.Tanque;
                    fila["Ultimo movimiento"] = item.TipoMovimiento;
                    fila["Pozo"] = item.Pozo;
                    fila["Nivel"] = item.Nivel;
                    fila["Interfase"] = item.Interfase;
                    fila["API"] = item.Api;
                    fila["SyW"] = item.Syw;
                    fila["Temp Fluido °F"] = item.TemFluido;
                    fila["Temp Ambiente °F"] = item.TemAmbiente;
                    fila["TOV"] = item.Tov;
                    fila["FW"] = item.Fw;
                    fila["CTSh"] = item.Ctsh;
                    fila["CTL"] = item.Ctl;
                    fila["GOV"] = item.Gov;
                    fila["GSV"] = item.Gsv;
                    fila["NSV"] = item.Nsv;
                    fila["SyW(Bls)"] = item.Sywbls;
                    table.Rows.Add(fila);
                };

                using var libro = new XLWorkbook();
                table.TableName = "Registros";
                var hoja = libro.Worksheets.Add(table);
                hoja.ColumnsUsed().AdjustToContents();

                using var memoria = new MemoryStream();
                libro.SaveAs(memoria);
                var nombreExcel = "Reporte.xlsx";
                var archivo = File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
                return archivo;
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}