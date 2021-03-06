using ATuSalud.ViewData;
using ConexionSQL.Models;
using Demostracion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Controllers
{
    public class SqlQuery_17 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_17(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }
        public IActionResult Index()
        {
            ViewBag.Especialidad = new SelectList(_context.TablaProfesional, "especialidad", "especialidad");
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(SqlQuery_17Param p)
        {
            string sql = " SELECT c.nombre,p.especialidad " +
                         " FROM tablaprofesional p " + 
                         " INNER JOIN tablaCentros c ON(c.id= p.id_centro) " +
                         " WHERE 1=1 " +
                         (p.especialidad != null && p.especialidad != "todos" ? " AND p.especialidad = @especialidad" : "");

            MySqlParameter[] param =
             {
                new MySqlParameter ("@especialidad", p.especialidad)
            };
            List<SqlQuery_17ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_17ViewData>(
                    _context, sql,
                    x => new SqlQuery_17ViewData()
                    {
                        nombre = x.GetString(0),
                        especialidad = x.GetString(1),
                    },param
                );
            ViewBag.Especialidad = new SelectList(_context.TablaProfesional, "especialidad", "especialidad");
            return View(lista);
        }
    }
}
