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
    public class SqlQuery_12 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_12(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }

        public IActionResult Index()
        {
            ViewBag.Profesional = new SelectList(_context.TablaProfesional, "id", "nombre");
            ViewBag.Fecha = new SelectList(_context.TablaCitasPaciente, "Id", "Fecha_atencion");
            return View();
        }

        [HttpPost]
        public IActionResult Index(SqlQuery_12Param p)
        {
            ViewBag.Profesional = new SelectList(_context.TablaProfesional, "id", "nombre");
            ViewBag.Fecha = new SelectList(_context.TablaCitasPaciente, "Id", "Fecha_atencion");
            string sql = "SELECT cp.id, cp.Fecha_atencion, p.Nombre " + 
                " FROM tablacitaspaciente cp " + 
                " INNER JOIN tablaprofesional p ON(p.id = cp.Id_profesional) " +
                " WHERE 1=1 " +
                (p.fecha != null ? " AND cast(cp.Fecha_atencion as date) = @fecha" : "") +
                (p.idProfesional != null && p.idProfesional != 0 ? " AND cp.Id_Profesional = @idProfesional " : "");
            MySqlParameter[] param =
            {
                new MySqlParameter ("@fecha", p.fecha),
                new MySqlParameter ("@idProfesional", p.idProfesional)
            };

            List<SqlQuery_12ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_12ViewData>(
                    _context, sql,
                    x => new SqlQuery_12ViewData()
                    {
                        id = x.GetInt32(0),
                        fecha_atencion = x.GetDateTime(1),
                        nombreProfesional = x.GetString(2)
                    },
                    param
                );
            ViewBag.Profesional = new SelectList(_context.TablaProfesional, "id", "nombre", p.idProfesional);
            ViewBag.Fecha = p.fecha;
            return View(lista);
        }
    }
}
