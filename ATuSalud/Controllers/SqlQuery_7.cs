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
    public class SqlQuery_7 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_7(Contexto context, ServicioSQL sql)
        {
            _context = context;
            _sql = sql;
        }
        public IActionResult Index()
        {
            string sql = "SELECT p.nombre, p.apellido1, p.apellido2, AVG(episodiosAbiertos) FROM(SELECT id_paciente, COUNT(1) episodiosAbiertos FROM tablaepisodios WHERE fechafinal IS NULL GROUP BY id_paciente) e INNER JOIN tablaprofesional_paciente i ON(i.id_Paciente= e.id_paciente) INNER JOIN tablaprofesional p ON(p.id = i.id_profesional) GROUP BY p.id, p.nombre HAVING AVG(episodiosAbiertos) > 1";
            List<SqlQuery_7ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_7ViewData>(
                    _context, sql,
                    x => new SqlQuery_7ViewData()
                    {
                        nombre = x.GetString(0),
                        apellido1 = x.GetString(1),
                        apellido2 = x.GetString(2),
                        mediaEpisodios = (int)x.GetDouble(3)
                    }
                );
            return View(lista);
        }
    }
}
