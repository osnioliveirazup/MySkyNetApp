using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Infrastructure.Persistence.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.Property(autor => autor.Nome)
                .IsRequired();

            builder.Property(autor => autor.Email)
                .IsRequired();

            builder.Property(autor => autor.Descricao)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}
