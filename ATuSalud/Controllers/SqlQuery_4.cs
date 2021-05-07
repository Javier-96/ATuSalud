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
    public class SqlQuery_4 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_4(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT p.nombre, COUNT(1)/COUNT(DISTINCT c.Fecha_atencion) FROM tablaprofesional p INNER JOIN tablacitaspaciente c ON(p.id= c.Id_profesional) GROUP BY p.id";
            List<SqlQuery_4ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_4ViewData>(
                    _context, sql,
                    x => new SqlQuery_4ViewData()
                    {
                        nombre = x.GetString(0),
                        media = x.GetInt32(1)
                        

                    }
                );
            return View(lista);
        }
    }
}