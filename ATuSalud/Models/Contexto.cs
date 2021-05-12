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
        public virtual DbSet<TablaAntecedentes> TablaAntecedentes { get; set; }
        public virtual DbSet<TablaEpisodios> TablaEpisodios { get; set; }
        public virtual DbSet<TablaEspacios> TablaEspacios { get; set; }
        public DbSet<ATuSalud.Models.TablaRecetas> TablaRecetas { get; set; }
        public DbSet<ATuSalud.Models.TablaPatologias> TablaPatologias { get; set; }
        public DbSet<ATuSalud.Models.TablaMedicamentos> TablaMedicamentos { get; set; }

       

        public virtual DbSet<TablaDatosFisicos> TablaDatosFisicos { get; set; }
        public virtual DbSet<TablaCitasPaciente> TablaCitasPaciente { get; set; }
        
        public virtual DbSet<TablaProfesional> TablaProfesional { get; set; }
        public virtual DbSet<TablaReservaEspacios> TablaReservaEspacios { get; set; }
        public virtual DbSet<TablaProfesional_Paciente> TablaProfesional_Paciente{ get; set; }
        public DbSet<ATuSalud.Models.TablaRegistroCuenta> TablaRegistroCuenta { get; set; }
        public DbSet<ATuSalud.Models.TablaCodigoCiap> TablaCodigoCiap { get; set; }
        public DbSet<ATuSalud.Models.TablaIncompatibilidades> TablaIncompatibilidades { get; set; }

    }
}