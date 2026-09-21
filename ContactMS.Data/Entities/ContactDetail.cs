using ContactApp.Framework.Data.Entities;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data.Entities
{
    public class ContactDetail : BaseEntity, IContactDetail
    {
        public long ContactId { get; set; }
        public string ContactNumber { get; set; }
        public long? CreatedUserId { get; set; }
        public long? EditedUserId { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
