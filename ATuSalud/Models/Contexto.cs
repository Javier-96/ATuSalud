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
        public DbSet<ATuSalud.Models.TablaRecetas> TablaRecetas { get; set; }
        public DbSet<ATuSalud.Models.TablaPatologias> TablaPatologias { get; set; }
        public DbSet<ATuSalud.Models.TablaMedicamentos> TablaMedicamentos { get; set; }

       


        public virtual DbSet<TablaPaciente> TablaDatosFisicos { get; set; }
        public virtual DbSet<TablaCitasPaciente> TablaCitasPaciente { get; set; }
        
    }
}