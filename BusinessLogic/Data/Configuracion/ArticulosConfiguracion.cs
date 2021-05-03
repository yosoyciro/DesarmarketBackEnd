using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuracion
{
    public class ArticulosConfiguracion : IEntityTypeConfiguration<Articulos>
    {
        public void Configure(EntityTypeBuilder<Articulos> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(v => v.Id).HasColumnName("ArticulosId");

            builder.ToTable("Articulos");

            //Relaciones
            
        }
    }
}
