using ContactApp.Framework.Data.Entities;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data.Entities
{
    public class Contact : BaseEntity , IContact
    {

        public string Name { get; set; }
        public int isActive { get; set; }
        public long? CreatedUserId { get; set; }
        public long? EditedUserId { get; set; }
        public virtual ICollection<ContactDetail>? ContactDetails { get; set; } //navigation property

    }
}
