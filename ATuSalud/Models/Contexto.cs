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
    }
}