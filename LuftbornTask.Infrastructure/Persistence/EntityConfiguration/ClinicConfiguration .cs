using LuftbornTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Infrastructure.Persistence.EntityConfiguration
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id); 
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100); 
            builder.Property(c => c.Email).HasMaxLength(100); 
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
        }
    }
}
