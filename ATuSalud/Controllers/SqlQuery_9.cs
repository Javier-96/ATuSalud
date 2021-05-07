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
    public class SqlQuery_9 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_9(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index(int? id)
        {
            string sql = " SELECT e.id,p.Nombre,p.Apellido1,e.Nombre " +
                         " FROM tablaepisodios e " +
                         " INNER JOIN tablapaciente p " +
                         " ON(p.id = e.Id_Paciente) " +
                         " WHERE e.FechaFinal IS NULL  " +
                         
                         (id != null ? " AND p.id = @idPaciente" : "");

            MySqlParameter[] param =
            {
                 new MySqlParameter("@IdPaciente", id)
            };

            List<SqlQuery_9ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_9ViewData>(
                    _context, sql,
                    x => new SqlQuery_9ViewData()
                    {
                        id = x.GetInt32(0),
                        nombre  = x.GetString(1),
                        apellido1 = x.GetString(2),
                        Episodio=x.GetString(3)

                    },param
                );

            ViewBag.Paciente = new SelectList(_context.TablaPaciente, "Id", "Nombre", id);

            return View(lista);
        }
    }
}
