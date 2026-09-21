
namespace ContactApp.DTOs.ContactDetail
{
    public class CreateContactDetailDTO
    {
        public long ContactId { get; set; }
        public string ContactNumber { get; set; }
        public long? CreatedUserId { get; set; }
    }
}
