using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTOs.ContactDetail
{
    public class EditContactDetailDTO
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public string ContactNumber { get; set; }
        public long? EditedUserId { get; set; }
    }
}
