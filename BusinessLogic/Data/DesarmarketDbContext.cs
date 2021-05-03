using Core.Entidades;
using Core.Functions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class DesarmarketDbContext : DbContext
    {
        public DesarmarketDbContext(DbContextOptions<DesarmarketDbContext> options) : base(options) { }
        public DbSet<ArticulosStock> ArticulosStock { get; set; }
        public DbSet<Marcas> Marca { get; set; }
        public DbSet<Modelos> Modelo { get; set; }
        public DbSet<Articulos> Articulo { get; set; }
        public DbSet<Vehiculos> Vehiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
