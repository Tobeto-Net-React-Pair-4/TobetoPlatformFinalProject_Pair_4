using AutoMapper;
using Business.Dtos.Session;
using Business.Dtos.Session.Requests;
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
    public class SessionMappingProfile : Profile
    {
        public SessionMappingProfile()
        {
            CreateMap<Session, CreateSessionRequest>().ReverseMap();
            CreateMap<Session, UpdateSessionRequest>().ReverseMap();

            CreateMap<Session, CreatedSessionResponse>().ReverseMap();
            CreateMap<Session, UpdatedSessionResponse>().ReverseMap();
            CreateMap<Session, DeletedSessionResponse>().ReverseMap();
            CreateMap<Session, GetSessionResponse>().ReverseMap();



            CreateMap<Session, GetListSessionResponse>().ReverseMap();
            CreateMap<Paginate<Session>, Paginate<GetListSessionResponse>>().ReverseMap();
        }
    }
}
