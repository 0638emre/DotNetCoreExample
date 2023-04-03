using AutoMapper;
using Bussiness.DTOs;
using Domain.Entities;

namespace Bussiness.Mapping.Automapping
{
    public class MeetProfile : Profile
    {
        public MeetProfile()
        {
            CreateMap<MeetDTO, Meet>();
            CreateMap<Meet, MeetDTO>();

            CreateMap<CreateMeetDTO, Meet>();
            CreateMap<Meet, CreateMeetDTO>();

            CreateMap<Meet, UpdateMeetDTO>();
            CreateMap<UpdateMeetDTO, Meet>();

        }
    }
}
