﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infraestructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.UserId);
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
            .HasColumnName("IdUsuario");

            builder.Property(e => e.DateBirth)
            .HasColumnName("FechaNacimiento");

            builder.Property(e => e.Telephone)
            .HasColumnName("Telefono");

            builder.Property(e => e.LastName)
            .HasColumnName("Apellidos");

            builder.Property(e => e.IsActive)
            .HasColumnName("Activo");

            builder.Property(e => e.FirstName)
            .HasColumnName("Nombres")
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);



            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.DateBirth).HasColumnType("date");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
