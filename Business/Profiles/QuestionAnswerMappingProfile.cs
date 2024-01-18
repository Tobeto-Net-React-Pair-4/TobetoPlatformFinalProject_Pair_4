using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.QuestionAnswer.Requests;
using Business.Dtos.QuestionAnswer.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class QuestionAnswerMappingProfile : Profile
    {
        public QuestionAnswerMappingProfile()
        {
            CreateMap<QuestionAnswer, CreateQuestionAnswerRequest>().ReverseMap();
            CreateMap<QuestionAnswer, DeleteQuestionAnswerRequest>().ReverseMap();
            CreateMap<QuestionAnswer, UpdateQuestionAnswerRequest>().ReverseMap();
            CreateMap<QuestionAnswer, GetByIdQuestionAnswerRequest>().ReverseMap();

            CreateMap<QuestionAnswer, CreatedQuestionAnswerResponse>().ReverseMap();
            CreateMap<QuestionAnswer, DeletedQuestionAnswerResponse>().ReverseMap();
            CreateMap<QuestionAnswer, UpdatedQuestionAnswerResponse>().ReverseMap();
            CreateMap<QuestionAnswer, GetByIdQuestionAnswerResponse>().ReverseMap();
            CreateMap<QuestionAnswer, GetListQuestionAnswerResponse>().ReverseMap();
            CreateMap<Paginate<QuestionAnswer>, Paginate<GetListQuestionAnswerResponse>>().ReverseMap();
        }
    }
}
