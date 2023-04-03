using System.Collections.ObjectModel;
using Domain.Entities;

namespace Bussiness.DTOs;

public class AddDocumentToMeetDTO
{
    public Guid MeetId { get; }
    public Collection<Guid> DocumentIds { get; }
}