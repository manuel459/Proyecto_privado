using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Data.Configuration
{

    //Configuration para implementar interfaz 
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.PostId);

            builder.ToTable("Publicacion");

            builder.HasKey(e => e.PostId);
            builder.Property(e => e.PostId)
            .HasColumnName("IdPublicacion");


            builder.Property(e => e.UserId)
            .HasColumnName("IdUsuario");

            builder.Property(e => e.Description)
            .HasColumnName("Descripcion");

            builder.Property(e => e.Image)
            .HasColumnName("Imagen");

            builder.Property(e => e.Date)
            .HasColumnName("Fecha");


            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        }
    }
}
