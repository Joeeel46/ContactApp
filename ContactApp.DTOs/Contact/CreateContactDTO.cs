
namespace ContactApp.DTOs.Contact
{
    public class CreateContactDTO
    {
        public string Name { get; set; }
        public int isActive { get; set; }
        public long? CreatedUserId { get; set; }
    }
}
