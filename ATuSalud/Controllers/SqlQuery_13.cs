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
    public class SqlQuery_13 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_13(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }


        public IActionResult Index()
        {
            ViewBag.Paciente = new SelectList(_context.TablaPaciente, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Index(SqlQuery_13Param p)
        {
            ViewBag.Paciente = new SelectList(_context.TablaPaciente, "Id", "Nombre");
            string sql = "SELECT p.Nombre,p.Apellido1,p.Apellido2,cp.Fecha_atencion,cp.Fecha_acabar,cp.Fecha_registro " +
                " FROM tablacitaspaciente cp " +
                " INNER JOIN tablapaciente p ON(p.id = cp.Id_paciente) " +
                " WHERE 1=1 " +
                (p.idPaciente != null && p.idPaciente != 0 ? " AND cp.Id_paciente = @idPaciente " : "");
            MySqlParameter[] param =
            {
                new MySqlParameter ("@idPaciente", p.idPaciente)
            };

            List<SqlQuery_13ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_13ViewData>(
                    _context, sql,
                    x => new SqlQuery_13ViewData()
                    {
                        Nombre = x.GetString(0),
                        Apellido1 = x.GetString(1),
                        Apellido2 = x.GetString(2),
                        Fecha_atencion = x.GetDateTime(3),
                        Fecha_acabar = x.GetDateTime(4),
                        Fecha_registro = x.GetDateTime(5)
                    },
                    param
                );

            return View(lista);
        }


    }
}
