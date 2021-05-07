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
    public class SqlQuery_3 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_3(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT codigo AS Codigo,c.enfermedad AS Enfermedad,p.Descripcion FROM tablapatologias p INNER JOIN tablacodigociap c ON(c.id= p.TablaCodigoCIAPId) ORDER BY codigo";
            List<SqlQuery_3ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_3ViewData>(
                    _context, sql,
                    x => new SqlQuery_3ViewData()
                    {
                        Codigo = x.GetString(0),
                        Enfermedad = x.GetString(1),
                        Descripcion = x.GetString(2),
                    }
                );
            return View(lista);
        }
    }
}
