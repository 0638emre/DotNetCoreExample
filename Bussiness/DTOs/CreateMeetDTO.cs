using Domain.Entities;

namespace Bussiness.DTOs
{
    public class CreateMeetDTO
    {
        public string MeetName { get; set; }
        public string MeetDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
