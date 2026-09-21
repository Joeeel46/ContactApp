using ContactApp.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data.Contract
{
    public interface IContactDetail : IAuditable, IEntity
    {

        public long ContactId { get; set; }
        public string ContactNumber { get; set; }

    }
}
