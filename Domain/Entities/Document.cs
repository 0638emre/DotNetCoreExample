namespace Domain.Entities
{
    public class Document : BaseEntity
    {
        public string DocumentName { get; set; }
        public Guid MeetId { get; set; }
        public Meet Meet { get; set; }
    }
}
