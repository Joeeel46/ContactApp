using ContactApp.DTOs.ContactDetail;

namespace ContactApp.DTOs.Contact
{
    public class CreateContactRequestDTO
    {
        public string Name { get; set; }
        public int isActive { get; set; }
        public long? CreatedUserId { get; set; }

        public List<CreateContactDetailRequestDTO>? ContactDetails { get; set; }
    }
}