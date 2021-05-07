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
    public class SqlQuery_11 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_11(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index(int? id)
        {
            string sql = "SELECT p.nombre NombrePaciente, pro.nombre NombreProfesional, m.Nombre_medicamento " +
                           " FROM tablarecetas r " +
                           " INNER JOIN tablapaciente p " +
                           " ON(p.id = r.ID_Paciente) " +
                           " INNER JOIN tablaprofesional_paciente pp " +
                           " ON(p.id = pp.Id_Paciente) " +
                           " INNER JOIN tablaprofesional pro " +
                           " ON(pro.id = pp.Id_Profesional) " +
                           " INNER JOIN tablamedicamentos m " +
                           " ON(m.id = r.Id_medicamento) " +
                           " WHERE 1=1 " +
                            (id != null ? " AND pro.id = @idProfesional" : "");

            MySqlParameter[] param =
            {
                new MySqlParameter("@idProfesional", id)
            };
            List<SqlQuery_11ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_11ViewData>(
                    _context, sql,
                    x => new SqlQuery_11ViewData()
                    {
                        NombrePaciente = x.GetString(0),
                        NombreProfesional = x.GetString(1),
                        Nombre_medicamento = x.GetString(2),
                    },param
                );
            ViewBag.Profesional = new SelectList(_context.TablaProfesional, "id", "nombre", id);
            return View(lista);
        }
    }
}
