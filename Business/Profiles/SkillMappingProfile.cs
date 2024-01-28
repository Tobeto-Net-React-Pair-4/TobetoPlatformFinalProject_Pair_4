using AutoMapper;
using Business.Dtos.Skill.Requests;
using Business.Dtos.Skill.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SkillMappingProfile : Profile
    {
        public SkillMappingProfile()
        {
            CreateMap<Skill, CreateSkillRequest>().ReverseMap();
            CreateMap<Skill, DeleteSkillRequest>().ReverseMap();
            CreateMap<Skill, UpdateSkillRequest>().ReverseMap();
            CreateMap<Skill, GetByIdSkillRequest>().ReverseMap();
            CreateMap<Skill, CreatedSkillResponse>().ReverseMap();
            CreateMap<Skill, UpdatedSkillResponse>().ReverseMap();
            CreateMap<Skill, DeletedSkillResponse>().ReverseMap();

            CreateMap<Skill, GetListSkillResponse>().ReverseMap();
            CreateMap<Skill, GetByIdSkillResponse>().ReverseMap();

            CreateMap<Paginate<Skill>, Paginate<GetListSkillResponse>>().ReverseMap();

        }
    }
}
