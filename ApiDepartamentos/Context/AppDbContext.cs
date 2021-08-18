using ApiDepartamentos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDepartamentos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Departamento> Departamentos {get;set;}
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Gerentes> Gerentes { get; set; }
    }
}
