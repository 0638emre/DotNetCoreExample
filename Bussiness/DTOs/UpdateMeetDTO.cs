namespace Bussiness.DTOs
{
    public class UpdateMeetDTO
    {
        public Guid MeetId { get; set; }
        public string MeetName { get; set; }
        public string MeetDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
