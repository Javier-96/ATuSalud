using ATuSalud.ViewData;
using ConexionSQL.Models;
using Demostracion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Controllers
{
    public class SqlQuery_15 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_15(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT p.nombre,p.apellido1,p.apellido2 FROM tablacitaspaciente cp INNER JOIN tablapaciente p ON(p.id= cp.Id_paciente) WHERE cp.Asistencia = 'No' AND Fecha_acabar<CURDATE()";
            List<SqlQuery_15ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_15ViewData>(
                    _context, sql,
                    x => new SqlQuery_15ViewData()
                    {
                        Nombre = x.GetString(0),
                        Apellido1 = x.GetString(1),
                        Apellido2 = x.GetString(2),
                    }
                );
            return View(lista);
        }
    }
}
