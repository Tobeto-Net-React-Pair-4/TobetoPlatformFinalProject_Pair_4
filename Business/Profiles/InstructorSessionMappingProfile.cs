using AutoMapper;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class InstructorSessionMappingProfile : Profile
    {
        public InstructorSessionMappingProfile()
        {
            CreateMap<Instructor, CreateInstructorSessionRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorSessionResponse>()
                .ForMember(destinationMember: i => i.InstructorName, memberOptions: opt => opt.MapFrom(cisr => cisr.Name))
                .ReverseMap();

            CreateMap<Instructor, DeleteInstructorSessionRequest>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorSessionResponse>()
                .ForMember(destinationMember: i => i.InstructorName, memberOptions: opt => opt.MapFrom(cisr => cisr.Name))
                .ReverseMap();

            CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>();
            CreateMap<Instructor, GetListInstructorSessionResponse>()
                .ForMember(destinationMember: i => i.InstructorName, memberOptions: opt => opt.MapFrom(cisr => cisr.Name))
                .ReverseMap();

            //CreateMap<Instructor, GetInstructorSessionRequest>().ReverseMap();
            //CreateMap<Instructor, GetInstructorSessionResponse>()
            //    .ForMember(destinationMember: i => i.InstructorName, memberOptions: opt => opt.MapFrom(cisr => cisr.Name))
            //    .ReverseMap();

            CreateMap<InstructorSession, GetListSessionResponse>()
               .IncludeMembers(ins => ins.Session)
               .ForMember(destinationMember: lsr => lsr.Id, memberOptions: opt => opt.MapFrom(s => s.SessionId))
               .ReverseMap();

            CreateMap<Paginate<InstructorSession>, Paginate<GetListSessionResponse>>().ReverseMap();
        }
    }
}
