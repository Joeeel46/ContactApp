using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Framework.Data.Entities
{
    public interface IAuditable
    {

        long? CreatedUserId { get; set; }

        long? EditedUserId { get; set; }

    }
}
