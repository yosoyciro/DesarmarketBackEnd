using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuracion
{
    public class VehiculosConfiguracion : IEntityTypeConfiguration<Vehiculos>
    {
        public void Configure(EntityTypeBuilder<Vehiculos> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder.Property(v => v.Id).HasColumnName("VehiculosId");

            builder.ToTable("Vehiculos");

            //Relaciones
            builder.HasOne(v => v.Marca).WithMany().HasForeignKey(v => v.MarcasId);
            builder.HasOne(v => v.Modelo).WithMany().HasForeignKey(v => v.ModelosId);
        }
    }
}
