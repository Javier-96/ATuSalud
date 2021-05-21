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
    public class DashboardAjax2 : Controller
    {
        private readonly Contexto _context;
        private readonly ServicioSQL _sql;

        public DashboardAjax2(Contexto context, ServicioSQL _sql)
        {
            this._context = context;
            this._sql = _sql;
        }

        public IActionResult Index()
        {
            ViewBag.Anyo = new SelectList(_context.TablaEpisodios.Select(x => new { Anyo = x.FechaInicio.Value.Year }).Distinct(), "Anyo", "Anyo");  //SELECT DISTINCT YEAR(FechaInicio) FROM TablaEpisodios
            ViewBag.CodigosCIAP = new SelectList(_context.TablaCodigoCiap, "Id", "Enfermedad");
            return View();
        }

        public IActionResult Listado1(int? Anyo = 0, int? CodigoCIAPId = 0)
        {
            string sql = " SELECT tMes.nmes, COUNT(1) " +
                " FROM tablaepisodios e " +
                " INNER JOIN (SELECT 1 mes, 'Enero' nmes UNION ALL SELECT 2 mes, 'Febrero' nmes UNION ALL SELECT 3 mes, 'Marzo' nmes UNION ALL " +
                " SELECT 4 mes, 'Abril' nmes UNION ALL SELECT 5 mes, 'Mayo' nmes UNION ALL SELECT 6 mes, 'Junio' nmes UNION ALL " +
                " SELECT 7 mes, 'Julio' nmes UNION ALL SELECT 8 mes, 'Agosto' nmes UNION ALL SELECT 9 mes, 'Septiembre' nmes UNION ALL " +
                " SELECT 10 mes, 'Octubre' nmes UNION ALL SELECT 11 mes, 'Noviembre' nmes UNION ALL " +
                " SELECT 12 mes, 'Diciembre' nmes) tMes ON(MONTH(FechaInicio) = tMes.mes) " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NULL " +
                (Anyo != 0 ? " AND YEAR(e.FechaInicio) = @Anyo " : "") +
                (CodigoCIAPId != 0 ? " AND e.ID_CodigoCIAP = @CodigoCIAPId " : "") +
                " GROUP BY tMes.nmes ";

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@Anyo", Anyo),
                new MySqlParameter("@CodigoCIAPId", CodigoCIAPId),
            };

            List<Dashboard2Listado1> lista =
            _sql.EjecutarSQL<Dashboard2Listado1>(
                    _context, sql,
                    x => new Dashboard2Listado1()
                    {
                        mes = x.GetString(0),
                        pacientes = x.GetInt32(1)
                    }, parametros
                );
            return PartialView(lista);
        }

        public IActionResult Listado2(int? Anyo = 0, int? CodigoCIAPId = 0)
        {
            string sql = " SELECT p.nombre, COUNT(1) " +
                " FROM tablaepisodios e " +
                " INNER JOIN tablapaciente p ON(e.Id_Paciente = p.Id) " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NULL " +
                (Anyo != 0 ? " AND YEAR(e.FechaInicio) = @Anyo " : "") +
                (CodigoCIAPId != 0 ? " AND e.ID_CodigoCIAP = @CodigoCIAPId " : "") +
                " GROUP BY p.Id, p.nombre";

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@Anyo", Anyo),
                new MySqlParameter("@CodigoCIAPId", CodigoCIAPId),
            };

            List<Dashboard2Listado2> lista =
            _sql.EjecutarSQL<Dashboard2Listado2>(
                    _context, sql,
                    x => new Dashboard2Listado2()
                    {
                        mes = x.GetString(0),
                        recetas = x.GetInt32(1)
                    }, parametros
                );
            return PartialView(lista);
        }

        public IActionResult Listado3(int? Anyo = 0, int? CodigoCIAPId = 0)
        {
            string sql = " SELECT tMes.nmes, COUNT(1) " +
                " FROM tablaepisodios e " +
                " INNER JOIN (SELECT 1 mes, 'Enero' nmes UNION ALL SELECT 2 mes, 'Febrero' nmes UNION ALL SELECT 3 mes, 'Marzo' nmes UNION ALL " +
                " SELECT 4 mes, 'Abril' nmes UNION ALL SELECT 5 mes, 'Mayo' nmes UNION ALL SELECT 6 mes, 'Junio' nmes UNION ALL " +
                " SELECT 7 mes, 'Julio' nmes UNION ALL SELECT 8 mes, 'Agosto' nmes UNION ALL SELECT 9 mes, 'Septiembre' nmes UNION ALL " +
                " SELECT 10 mes, 'Octubre' nmes UNION ALL SELECT 11 mes, 'Noviembre' nmes UNION ALL " +
                " SELECT 12 mes, 'Diciembre' nmes) tMes ON(MONTH(FechaInicio) = tMes.mes) " +
                " WHERE 1=1 " +
                " AND e.FechaFinal IS NOT NULL " +
                (Anyo != 0 ? " AND YEAR(e.FechaInicio) = @Anyo " : "") +
                (CodigoCIAPId != 0 ? " AND e.ID_CodigoCIAP = @CodigoCIAPId " : "") +
                " GROUP BY tMes.nmes " +
                " ORDER BY MONTH(FechaInicio) ";

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@Anyo", Anyo),
                new MySqlParameter("@CodigoCIAPId", CodigoCIAPId),
            };

            List<Dashboard2Listado3> lista =
            _sql.EjecutarSQL<Dashboard2Listado3>(
                    _context, sql,
                    x => new Dashboard2Listado3()
                    {
                        paciente = x.GetString(0),
                        recetas = x.GetInt32(1)
                    }, parametros
                );
            return PartialView(lista);
        }

        public IActionResult Listado4(int? Anyo = 0, int? CodigoCIAPId = 0)
        {
            string sql = " SELECT p.nombre, r.Fecha " +
                " FROM tablapaciente p " +
                " INNER JOIN tablarecetas r ON(r.ID_Paciente = p.Id) " +
                " INNER JOIN tablaepisodios e ON(r.ID_Episodio = e.Id) " +
                " WHERE 1=1 " +
                (Anyo != 0 ? " AND YEAR(r.Fecha) = @Anyo " : "") +
                (CodigoCIAPId != 0 ? " AND e.ID_CodigoCIAP = @CodigoCIAPId " : "") +
                " GROUP BY p.Id, p.nombre ORDER BY COUNT(1) DESC " +
                " LIMIT 5 ";

            MySqlParameter[] parametros =
            {
                new MySqlParameter("@Anyo", Anyo),
                new MySqlParameter("@CodigoCIAPId", CodigoCIAPId),
            };

            List<Dashboard2Listado4> lista =
            _sql.EjecutarSQL<Dashboard2Listado4>(
                    _context, sql,
                    x => new Dashboard2Listado4()
                    {
                        paciente = x.GetString(0),
                        fecha = x.GetDateTime(1)
                    }, parametros
                );
            return PartialView(lista);
        }
    }
}
