using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuracion
{
    public class ArticulosStockConfiguracion : IEntityTypeConfiguration<ArticulosStock>
    {
        public void Configure(EntityTypeBuilder<ArticulosStock> builder)
        {
            builder                
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(v => v.Id).HasColumnName("ArticulosStockId");

            builder.Property(a => a.CodigoBarra).IsRequired();

            //Precio

            //Relaciones
            builder.HasOne(a => a.Vehiculo).WithMany().HasForeignKey(a => a.VehiculosId);
            builder.HasOne(a => a.Articulo).WithMany().HasForeignKey(a => a.ArticulosId);
        }
    }
}
