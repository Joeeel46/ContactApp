namespace ContactApp.DTOs.Contact
{
    public class ContactDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int isActive { get; set; }
        public long? CreatedUserId { get; set; }
        public long? EditedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
    }
}
