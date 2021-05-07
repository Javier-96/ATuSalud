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
    public class SqlQuery_10 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_10(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index(int? id)
        {

            MySqlParameter[] param =
            {
                new MySqlParameter("@id", id),
             
            };

            string sql = "SELECT p.nombre,r.Id_medicamento,m.Nombre_medicamento FROM tablarecetas r " +
                "INNER JOIN tablapaciente p ON(p.id=r.ID_Paciente) " +
                "INNER JOIN tablamedicamentos m ON(m.id=r.Id_medicamento) " +
                "WHERE 1=1 " +
                (id != null ? " AND p.id = @id" : "");
            List<SqlQuery_10ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_10ViewData>(
                    _context, sql,
                    x => new SqlQuery_10ViewData()
                    {
                        nombre_pacientes = x.GetString(0),
                        Id_medicamento = x.GetInt32(1),
                        Nombre_medicamento = x.GetString(2)

                    },param

                );

            ViewBag.Pac = new SelectList(_context.TablaPaciente, "Id", "Nombre", id);

            return View(lista);
        }
    }
}
