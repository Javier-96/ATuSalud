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
    public class SqlQuery_19 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_19(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }

   

        //[HttpPost]
        public IActionResult Index()
        {
            ViewBag.Profesional = new SelectList(_context.TablaProfesional, "id", "nombre");
            ViewBag.Fecha = new SelectList(_context.TablaCitasPaciente, "Id", "Fecha_atencion");
            string sql = " SELECT m.Nombre_medicamento,es.nombre_efecto " +
                        " FROM tablamedicamentos m " +
                        " INNER JOIN TablaMedicamento_efectos ms ON(ms.id_medicamento = m.id) " +
                        " INNER JOIN Tablaefectos_secundarios es ON(es.id = ms.id) " +
                        " WHERE es.severidad = 'Grave'; ";
        

            List<SqlQuery_19ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_19ViewData>(
                    _context, sql,
                    x => new SqlQuery_19ViewData()
                    {
                        nombre_medicamento = x.GetString(0),
                        nombre_efecto = x.GetString(1)
                    }
                    
                );
         
            return View(lista);
        }
    }
}
