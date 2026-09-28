namespace ContactApp.DTOs.ContactDetail
{
    public class CreateContactDetailRequestDTO
    {
        public string ContactNumber { get; set; }
        public long? CreatedUserId { get; set; }
    }
}