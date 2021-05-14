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
            string sql = " SELECT p.id,p.Nombre,p.Apellido1,p.Apellido2 " +
                         " FROM tablapaciente p " +
                          " WHERE id IN( " +
                                 " SELECT tr.id_paciente " +
                                 " FROM tablaincompatibilidades ti " +
                                 " INNER JOIN tablarecetas tr ON(tr.id_medicamento = ti.id_medicamento) " +
                                 " INNER JOIN tablarecetas tr2 ON(tr2.id_medicamento = ti.id_medicamento_incompatible) " +
                                 " WHERE tr.id_paciente = tr2.id_paciente AND tr.dias_regenerado != 0 )";

            List<SqlQuery_16ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_16ViewData>(
                    _context, sql,
                    x => new SqlQuery_16ViewData()
                    {
                        id_paciente = x.GetInt32(0),
                        nombre= x.GetString(1),
                        apellido1 = x.GetString(2),
                        apellido2 = x.GetString(3)
                    }
                );
            return View(lista);
        }
    }
}
