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
    public class DashboardAjax : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public DashboardAjax(Contexto context, ServicioSQL _sql)
        {
            this._context = context;
            this._sql = _sql;
        }

        public IActionResult Index()
        {
            ViewBag.Anyo = new SelectList(_context.TablaEpisodios.Select(x=>new { Anyo=x.FechaInicio.Value.Year  }).Distinct(), "Anyo", "Anyo");  //SELECT DISTINCT YEAR(FechaInicio) FROM TablaEpisodios
            ViewBag.CodigosCIAP = new SelectList(_context.TablaCodigoCiap, "Id", "Enfermedad");
            return View();
        }

        public IActionResult Listado1(int? Anyo = 0, int? CodigoCIAPId = 0)
        {
            string sql = " SELECT MONTH(FechaInicio), COUNT(1) " +
                " FROM tablaepisodios e " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NULL " +
                " AND YEAR(e.FechaInicio) = @Anyo " +
                " GROUP BY MONTH(FechaInicio) ";
            List<Dashboard1Listado1> lista =
            _sql.EjecutarSQL<Dashboard1Listado1>(
                    _context, sql,
                    x => new Dashboard1Listado1()
                    {
                        mes = x.GetInt32(0),
                        episodios = x.GetInt32(1)
                    }
                );

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@Anyo", Anyo),
                new MySqlParameter("@CodigoCIAPId", CodigoCIAPId),
            };

            return PartialView(lista);
        }

        public IActionResult Listado2()
        {
            string sql = " SELECT p.nombre, COUNT(1) " +
                " FROM tablaepisodios e " +
                " INNER JOIN tablapaciente p ON(e.Id_Paciente = p.Id) " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NULL " +
                " GROUP BY p.Id, p.nombre";
            List<Dashboard1Listado2> lista =
            _sql.EjecutarSQL<Dashboard1Listado2>(
                    _context, sql,
                    x => new Dashboard1Listado2()
                    {
                        nombre = x.GetString(0),
                        episodiosAbiertos = x.GetInt32(1)
                    }
                );
            return PartialView(lista);
        }

        public IActionResult Listado3()
        {
            string sql = " SELECT MONTH(FechaInicio), COUNT(1) " +
                " FROM tablaepisodios e " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NOT NULL " +
                " GROUP BY MONTH(FechaInicio) ";
            List<Dashboard1Listado3> lista =
            _sql.EjecutarSQL<Dashboard1Listado3>(
                    _context, sql,
                    x => new Dashboard1Listado3()
                    {
                        mes = x.GetInt32(0),
                        episodios = x.GetInt32(1)
                    }
                );
            return PartialView(lista);
        }

        public IActionResult Listado4()
        {
            string sql = " SELECT p.nombre, COUNT(1) " +
                " FROM tablapaciente p " +
                " INNER JOIN tablarecetas r ON(r.ID_Paciente = p.Id) " +
                " WHERE 1=1 " +
                " GROUP BY p.Id, p.nombre ORDER BY COUNT(1) DESC " +
                " LIMIT 5 ";
            List<Dashboard1Listado4> lista =
            _sql.EjecutarSQL<Dashboard1Listado4>(
                    _context, sql,
                    x => new Dashboard1Listado4()
                    {
                        nombre = x.GetString(0),
                        citas = x.GetInt32(1)
                    }
                );
            return PartialView(lista);
        }
    }
}
