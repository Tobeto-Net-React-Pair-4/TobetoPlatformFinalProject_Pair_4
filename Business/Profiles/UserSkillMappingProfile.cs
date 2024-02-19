using AutoMapper;
using Business.Dtos.UserSkill.Requests;
using Business.Dtos.UserSkill.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserSkillMappingProfile : Profile
    {
        public UserSkillMappingProfile()
        {
            CreateMap<UserSkill, CreateUserSkillRequest>().ReverseMap();
            CreateMap<UserSkill, DeleteUserSkillRequest>().ReverseMap();
            CreateMap<UserSkill, CreatedUserSkillResponse>().ReverseMap();
            CreateMap<UserSkill, DeletedUserSkillResponse>().ReverseMap();
            CreateMap<UserSkill, GetListUserSkillResponse>().ReverseMap();


            CreateMap<Paginate<UserSkill>, Paginate<GetListUserSkillResponse>>().ReverseMap();

        }
    }
}
