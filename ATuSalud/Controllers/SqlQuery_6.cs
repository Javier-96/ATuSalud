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
    public class SqlQuery_6 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_6(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT p.nombre, p.apellido1, p.apellido2, COUNT(1) AS 'Numero de medicamentos' FROM tablarecetas r INNER JOIN tablapaciente p ON(p.id = r.ID_paciente) GROUP BY r.ID_paciente HAVING COUNT(1) >= 2";
            List<SqlQuery_6ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_6ViewData>(
                    _context, sql,
                    x => new SqlQuery_6ViewData()
                    {
                        nombre = x.GetString(0),
                        apellido1 = x.GetString(1),
                        apellido2 = x.GetString(2),
                        numMedicamentos = x.GetInt32(3)
                    }
                );
            return View(lista);
        }
    }
}
