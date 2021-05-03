using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuracion
{
    public class MarcasConfiguracion : IEntityTypeConfiguration<Marcas>
    {        
        public void Configure(EntityTypeBuilder<Marcas> builder)
        {
            builder
               .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(v => v.Id).HasColumnName("MarcasId");

            builder.ToTable("Marcas");

            //Relaciones
        }
    }
}
