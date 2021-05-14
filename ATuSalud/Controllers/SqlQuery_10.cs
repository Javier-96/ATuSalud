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

            string sql = "SELECT p.nombre,p.apellido1,p.apellido2,m.Nombre_medicamento,r.diagnostico,ifnull(r.cantidad,''),ifnull(r.dosis,''),ifnull(r.duracion,''),ifnull(r.fecha,'') " +
                " FROM tablarecetas r " +
                " INNER JOIN tablapaciente p ON(p.id=r.ID_Paciente) " +
                " INNER JOIN tablamedicamentos m ON(m.id=r.Id_medicamento) " +
                " WHERE 1=1 " +
                (id != null ? " AND p.id = @id" : "");
            List<SqlQuery_10ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_10ViewData>(
                    _context, sql,
                    x => new SqlQuery_10ViewData()
                    {
                        nombre = x.GetString(0),
                        apellido1 = x.GetString(1),
                        apellido2 = x.GetString(2),
                        medicamento = x.GetString(3),
                        diagnostico = x.GetString(4),
                        cantidad = x.GetString(5),
                        dosis = x.GetString(6),
                        duracion = x.GetString(7),
                        fecha = x.GetString(8)

                    },param

                );

            ViewBag.Pac = new SelectList(_context.TablaPaciente, "Id", "Nombre", id);

            return View(lista);
        }
    }
}
