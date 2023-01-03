using Microsoft.AspNetCore.Mvc;
using ControWell.Shared;
using System.Diagnostics;


using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using ControWell.Shared;
using EFCore.BulkExtensions;
using ControWell.Shared;
using System.Diagnostics.Contracts;

namespace ProyectoExcel.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;
            List < Pozo> lista = new List<Pozo>();

            for (int i = 1; i <= cantidadFilas; i++)
            {

                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new Pozo
                {
                    NombrePozo = fila.GetCell(0).ToString(),
                    Ubicacion = fila.GetCell(1).ToString(),
                    Operadora = fila.GetCell(2).ToString(),
                    Comentario = fila.GetCell(3).ToString(),

                });
            }

            return StatusCode(StatusCodes.Status200OK, lista);
        }



    }
}