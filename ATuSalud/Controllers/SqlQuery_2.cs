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
    public class SqlQuery_2 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_2(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = " SELECT apellido1, apellido2, nombre, Fecha_de_nacimiento " +
                        " FROM tablapaciente " +
                        " WHERE TIMESTAMPDIFF(YEAR, Fecha_de_nacimiento, CURDATE()) < 18 " +
                        " ORDER BY apellido1,apellido2,nombre ";

            List<SqlQuery_2ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_2ViewData>(
                    _context, sql,
                    x => new SqlQuery_2ViewData()
                    {
                        apellido1 = x.GetString(0),
                        apellido2 = x.GetString(1),
                        nombre = x.GetString(2),
                        fecha_de_Nacimiento=x.GetDateTime(3)
                        
                    }
                );
            return View(lista);
        }
    }
}
