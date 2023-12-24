using AutoMapper;
using Business.Dtos.UserSurvey.Requests;
using Business.Dtos.UserSurvey.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserSurveyMappingProfile:Profile
    {
        public UserSurveyMappingProfile()
        {
            CreateMap<UserSurvey, CreateUserSurveyRequest>().ReverseMap();
            CreateMap<UserSurvey, DeleteUserSurveyRequest>().ReverseMap();
            
            CreateMap<UserSurvey, CreatedUserSurveyResponse>().ReverseMap();
          
            CreateMap<UserSurvey, DeletedUserSurveyResponse>().ReverseMap();

            CreateMap<UserSurvey, GetListUserSurveyResponse>().ReverseMap();
            CreateMap<Paginate<UserSurvey>, Paginate<GetListUserSurveyResponse>>().ReverseMap();
        }
    }
}
