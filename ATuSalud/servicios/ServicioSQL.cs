using ConexionSQL.Models;
using Demostracion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Demostracion
{
    public class ServicioSQL
    {
        public List<Tipo> EjecutarSQL<Tipo>(Contexto contexto, string sql, Func<DbDataReader, Tipo> leerRegistro, Array parametros = null)
        {
            using(DbCommand comando = contexto.Database.GetDbConnection().CreateCommand())
            {
                comando.CommandText = sql;
                comando.CommandType = CommandType.Text;
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }
                contexto.Database.OpenConnection(); //Conecta con la base de datos.
                using (DbDataReader dr = comando.ExecuteReader()) //DbDataReader es un vector de registros. Vector secuencial que lee linea por linea.
                {
                    List<Tipo> resultado = new List<Tipo>(); //Para cada elemento tenemos que añadir algo de tipo ViewData
                    while (dr.Read())
                    {
                        resultado.Add(leerRegistro(dr));
                    }
                    return resultado;
                }
            }
        }

    }
}
