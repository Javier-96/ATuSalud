using ATuSalud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionSQL.Models
{
    public class Contexto : DbContext
    {
        public Contexto([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<TablaPaciente> TablaPaciente { get; set; }
        public virtual DbSet<TablaProfesional> TablaProfesional { get; set; }
        public virtual DbSet<TablaReservaEspacios> TablaReservaEspacios { get; set; }
        public virtual DbSet<TablaProfesional_Paciente> TablaProfesional_Paciente{ get; set; }
    }
}