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
    public class SqlQuery_8 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_8(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        //Vamos a pasarlo por Get
        public IActionResult Index(int? idPaciente)
        {
            string sql = "SELECT a.id,c.codigo,c.enfermedad,p.nombre,p.apellido1,p.apellido2 " +
                "FROM tablaantecedentes a INNER JOIN tablapaciente p " +
                "ON(p.id = a.Id_paciente) INNER JOIN tablacodigociap c ON(c.id = a.id_ciap)" +
                " WHERE 1=1 " +
                (idPaciente != null ? " AND p.id = @id" : "");

            MySqlParameter[] param =
            {
                new MySqlParameter("@id", idPaciente)
            };

            List<SqlQuery_8ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_8ViewData>(
                    _context, sql,
                    x => new SqlQuery_8ViewData()
                    {
                        id_antecedente = x.GetInt32(0),
                        codigo = x.GetString(1),
                        enfermedad = x.GetString(2),
                        nombre = x.GetString(3),
                        apellido1 = x.GetString(4),
                        apellido2 =x.GetString(5)

                    },param
                );


            ViewBag.Pac = new SelectList(_context.TablaPaciente, "Id", "Nombre", idPaciente);
            
            return View(lista);
        }
    }
}
