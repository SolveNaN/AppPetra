using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ControWell.Shared;
using System.Diagnostics;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using ControWell.Shared;
using EFCore.BulkExtensions;
using ControWell.Shared;
using System.Diagnostics.Contracts;
using ClosedXML.Excel;
using System.Data;

namespace ControWell.Server.Controllers
{
    public class WeatherForecastController1 : Controller
    {
        public FileResult Index()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Edad");

            DataRow dr = dt.NewRow();
            dr["Nombre"] = "Omar";
            dr["Telefono"] = "3142970790";
            dr["Edad"] = "29";

            DataRow dr2 = dt.NewRow();
            dr2["Nombre"] = "Andres";
            dr2["Telefono"] = "3142970790";
            dr2["Edad"] = "26";
            dt.Rows.Add(dr);
            dt.Rows.Add(dr2);

            using (var libro = new XLWorkbook())
            {
                dt.TableName = "Clientes";
                var hoja = libro.Worksheets.Add(dt);
                hoja.ColumnsUsed().AdjustToContents();
                using (var memoria = new MemoryStream())
                {
                    libro.SaveAs(memoria);
                    var nombreExcel = string.Concat("Reporte", "xlsx");
                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
                }
            };
        }
    }
}