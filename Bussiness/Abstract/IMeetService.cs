using Bussiness.DTOs;

namespace Bussiness.Abstract
{
    public interface IMeetService
    {
        Task<MeetDTO> GetMeetByIdAsync(Guid meetId);
        Task<bool> CreateMeetAsync(CreateMeetDTO createMeet);
        Task<bool> AddUserToMeetAsync(AddUserToMeetDTO addUserToMeet);
        Task<bool> RemoveMeetAsync(Guid meetId);
        Task<bool> UpdateMeetAsync(UpdateMeetDTO updateMeet);
        Task<bool> AddDocumentToMeetAsync(AddDocumentToMeetDTO addDocumentToMeet);
    }
}
