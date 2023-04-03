using Domain.Entities;

namespace Bussiness.DTOs
{
    public class AddUserToMeetDTO
    {
        public Guid MeetId { get; set; }
        public ICollection<Guid> UserId { get; set; }
    }
}
