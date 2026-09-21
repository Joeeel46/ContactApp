using ContactMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data.Mappings
{
    public class ContactDetailMap : IEntityTypeConfiguration<ContactDetail>
    {
        public void Configure(EntityTypeBuilder<ContactDetail> builder)
        {
            _ = builder.ToTable("ContactDetails");
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.ContactNumber).IsRequired();
            _ = builder.Property(x => x.CreatedUserId);
            _ = builder.Property(x => x.EditedUserId);
            _ = builder.Property(x => x.CreatedDate);
            _ = builder.Property(x => x.EditedDate);
            _ = builder.HasOne(x => x.Contact).WithMany(x => x.ContactDetails).HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
