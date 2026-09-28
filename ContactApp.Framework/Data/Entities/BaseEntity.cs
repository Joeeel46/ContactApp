using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Framework.Data.Entities
{
    public abstract class BaseEntity : IEntity
    {
        #region Member Variable
        /// <summary>
        /// get or set Identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// get or set Created Date 
        /// </summary>
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// get or set Edited Date
        /// </summary>
        public DateTime? EditedDate { get; set; }
        #endregion
    }
}
