using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Framework.Data.Entities
{
    public interface IEntity
    {

        long Id { get; set;}

        DateTime? CreatedDate { get; set; }

        DateTime? EditedDate { get; set; }

    }
}
