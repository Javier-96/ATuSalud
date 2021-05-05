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
    public class SqlQuery_1 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_1(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT id, nombre, apellido1, apellido2, num_colegiado FROM tablaprofesional ORDER BY apellido1, nombre";
            List<ProfesionalViewData> lista =
            _sql.EjecutarSQL<ProfesionalViewData>(
                    _context, sql,
                    x => new ProfesionalViewData()
                    {
                        id = x.GetInt32(0),
                        nombre = x.GetString(1),
                        apellido1 = x.GetString(2),
                        apellido2 = x.GetString(3),
                        num_colegiado = x.GetInt32(4)
                    }
                );
            return View(lista);
        }
    }
}
