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
            string sql = " SELECT c.nombre,p.especialidad " +
                         " FROM tablaprofesional p " + 
                         " INNER JOIN tablaCentros c ON(c.id= p.id_centro) " +
                         " WHERE p.especialidad = 'Oncologia' ";
            List<SqlQuery_17ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_17ViewData>(
                    _context, sql,
                    x => new SqlQuery_17ViewData()
                    {
                        nombre = x.GetString(0),
                        especialidad = x.GetString(1),
                    }
                );
            return View(lista);
        }
    }
}
