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
    public class SqlQuery_16 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_16(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }

       // [HttpPost]
        public IActionResult Index()
        {
            string sql = " SELECT p.Nombre,p.Apellido1,p.Apellido2,tm.Nombre_medicamento,tm2.Nombre_medicamento " +
                        " FROM tablaincompatibilidades ti " +
                        " INNER JOIN tablarecetas tr ON(tr.id_medicamento = ti.id_medicamento) " +
                        " INNER JOIN tablarecetas tr2 ON(tr2.id_medicamento = ti.id_medicamento_incompatible) " +
                        " INNER JOIN tablapaciente p ON(tr2.id_paciente = p.id) " +
                        " INNER JOIN tablamedicamentos tm ON(tr.id_medicamento = tm.id) " +
                        " INNER JOIN tablamedicamentos tm2 ON(tr2.id_medicamento = tm2.id) " +
                        " WHERE tr.id_paciente = tr2.id_paciente AND tr.dias_regenerado != 0 ";


            List<SqlQuery_16ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_16ViewData>(
                    _context, sql,
                    x => new SqlQuery_16ViewData()
                    {
                      
                        nombre= x.GetString(0),
                        apellido1 = x.GetString(1),
                        apellido2 = x.GetString(2),
                        medicamento1=x.GetString(3),
                        medicamento2=x.GetString(4)
                    }
                );
            return View(lista);
        }
    }
}
