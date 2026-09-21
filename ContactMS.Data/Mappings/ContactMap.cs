using ContactMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            _ = builder.ToTable("Contacts");
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            _ = builder.Property(x => x.isActive).IsRequired();
            _ = builder.Property(x => x.CreatedUserId);
            _ = builder.Property(x => x.EditedUserId);
            _ = builder.Property(x => x.CreatedDate);
            _ = builder.Property(x => x.EditedDate);
        }
    }
}
