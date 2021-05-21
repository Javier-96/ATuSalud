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
    public class SqlQuery_18 : Controller
    {
        private readonly Contexto _context;
        //Ahorrar algoritmo recorrido etc
        private readonly ServicioSQL _sql;
        public SqlQuery_18(Contexto context, ServicioSQL sql)
        {
            this._context = context;
            this._sql = sql;
        }

        public IActionResult Index()
        {
            string sql = "SELECT p.nombre,p.Apellido1,c.codigo,c.Enfermedad,a.Familiar FROM tablapaciente p INNER JOIN tablaantecedentes a ON(p.id= a.Id_Paciente) INNER JOIN tablacodigociap c ON(c.id = a.id_ciap) WHERE c.Codigo LIKE 'P%'";
            List<SqlQuery_18ViewData> lista =
            _sql.EjecutarSQL<SqlQuery_18ViewData>(
                    _context, sql,
                    x => new SqlQuery_18ViewData()
                    { 
                        nombre = x.GetString(0),
                        apellido1=x.GetString(1),
                        codigo = x.GetString(2),
                        Enfermedad = x.GetString(3),
                        Familiar = x.GetString(4)
                    }
                );
            return View(lista);
        }
    }
}