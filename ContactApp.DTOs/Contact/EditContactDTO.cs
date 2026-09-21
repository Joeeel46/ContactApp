using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTOs.Contact
{
    public class EditContactDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int isActive { get; set; }
        public long? EditedUserId { get; set; }
    }
}
