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
    public class SqlQuery_5 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_5(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT nombre_medicamento,Forma_farmaceutica,es.nombre_efecto "+
                            " FROM tablamedicamentos m " +
                            " INNER JOIN tablaefectos_secundarios es ON(es.id= id_efectoSec) "+
                            " ORDER BY nombre_medicamento";

            List<SqlQuery_5ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_5ViewData>(
                    _context, sql,
                    x => new SqlQuery_5ViewData()
                    {

                        nombre_medicamento = x.GetString(0),
                        forma_farmaceutica = x.GetString(1),
                        nombre_efecto=x.GetString(2)

                    }
                );
            return View(lista);
        }
    }
}
