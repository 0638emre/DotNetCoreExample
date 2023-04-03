using System.Collections;
using AutoMapper;
using Bussiness.Abstract;
using Bussiness.CustomException;
using Bussiness.DTOs;
using DataAccess.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete
{
    public class MeetService : IMeetService
    {
        private readonly DotNetCoreExampleDB _context;
        private readonly IMapper _mapper;

        public MeetService(DotNetCoreExampleDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MeetDTO> GetMeetByIdAsync(Guid meetId)
        {
            Meet data = await _context.Meets.FindAsync(meetId);

            if (data is null)
            {
                throw new NotFound("Meet bulunamadı.");
            }

            //burada tek tek mapleme ile uğraşmayacağım. Bu sebeple automapper kullanıyorum. Hem de best practice

            MeetDTO meet = _mapper.Map<MeetDTO>(data);

            return meet;
        }

        public async Task<bool> CreateMeetAsync(CreateMeetDTO createMeet)
        {
            try
            {
                Meet meet = _mapper.Map<Meet>(createMeet);
                var data = await _context.Meets.AddAsync(meet);
                await _context.SaveChangesAsync();
                var meetEntity = data.Entity;

                if (meetEntity is not null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;

        }

        public async Task<bool> AddUserToMeetAsync(AddUserToMeetDTO addUserToMeet)
        {
            foreach (Guid subscriberId in addUserToMeet.UserId)
            {
                await _context.MeetUser.AddAsync(new MeetUser
                {
                    MeetId = addUserToMeet.MeetId,
                    SubscriberId = subscriberId
                });
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveMeetAsync(Guid meetId)
        {
            var data = _context.Meets.Remove(new() { Id = meetId });
            await _context.SaveChangesAsync();
            var meetEntity = data.Entity;
            if (meetEntity is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateMeetAsync(UpdateMeetDTO updateMeet)
        {
            Meet meet = _mapper.Map<Meet>(updateMeet);
            var data = _context.Meets.Update(meet);
            var meetEntity = data.Entity;

            await _context.SaveChangesAsync();
            
            if (meetEntity is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddDocumentToMeetAsync(AddDocumentToMeetDTO addDocumentToMeet)
        {
            var meet = await _context.Meets.FindAsync(addDocumentToMeet.MeetId);

            if (meet == null)
            {
                return false; // belirtilen toplantı bulunamadı
            }

            var document = await _context.Documents.FindAsync(addDocumentToMeet.DocumentIds);

            if (document == null)
            {
                return false; // belirtilen doküman bulunamadı
            }

            var documents = await _context.Documents
                .Where(d => addDocumentToMeet.DocumentIds.Contains(d.Id))
                .ToListAsync();

            meet.Documents = documents;

            _context.Meets.Update(new()
            {
                Id = addDocumentToMeet.MeetId,
                Documents = documents
            });

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
