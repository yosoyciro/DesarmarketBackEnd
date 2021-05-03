using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuracion
{
    public class ModelosConfiguracion : IEntityTypeConfiguration<Modelos>
    {
        public void Configure(EntityTypeBuilder<Modelos> builder)
        {
            builder
               .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(v => v.Id).HasColumnName("ModelosId");

            builder.ToTable("Modelos");

            //Relaciones
        }
    }
}
