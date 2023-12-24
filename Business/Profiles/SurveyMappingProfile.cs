using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class SurveyMappingProfile:Profile
    {
        public SurveyMappingProfile()
        {
            CreateMap<Survey, CreateSurveyRequest>().ReverseMap();
            CreateMap<Survey, DeleteSurveyRequest>().ReverseMap();
            CreateMap<Survey, UpdateSurveyRequest>().ReverseMap();
            CreateMap<Survey, CreatedSurveyResponse>().ReverseMap();
            CreateMap<Survey, UpdatedSurveyResponse>().ReverseMap();
            CreateMap<Survey, DeletedSurveyResponse>().ReverseMap();

            CreateMap<Survey, GetListSurveyResponse>().ReverseMap();
            CreateMap<Paginate<Survey>, Paginate<GetListSurveyResponse>>().ReverseMap();
        }
    }
}
