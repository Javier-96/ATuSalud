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
    }
}