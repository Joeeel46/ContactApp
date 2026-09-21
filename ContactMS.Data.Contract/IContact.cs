using System;
using System.Collections.Generic;
using System.Text;
using ContactApp.Framework.Data.Entities;

namespace ContactMS.Data.Contract
{
    public interface IContact: IAuditable , IEntity
    {
        string Name { get; set; }
        int isActive { get; set; }

    }
}
