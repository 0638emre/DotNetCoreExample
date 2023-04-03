namespace Domain.Entities
{
    public class MeetUser
    {
        public Guid MeetId { get; set; }
        public Meet Meet { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
 