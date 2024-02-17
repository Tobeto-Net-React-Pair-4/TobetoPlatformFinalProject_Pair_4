using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.ExamQuestion.Requests;
using Business.Dtos.ExamQuestion.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ExamQuestionMappingProfile : Profile
    {
        public ExamQuestionMappingProfile()
        {
            CreateMap<ExamQuestion, CreateExamQuestionRequest>().ReverseMap();
            CreateMap<ExamQuestion, UpdateExamQuestionRequest>().ReverseMap();

            CreateMap<ExamQuestion, CreatedExamQuestionResponse>().ReverseMap();
            CreateMap<ExamQuestion, DeletedExamQuestionResponse>().ReverseMap();
            CreateMap<ExamQuestion, UpdatedExamQuestionResponse>().ReverseMap();
            CreateMap<ExamQuestion, GetByIdExamQuestionResponse>()
                .ForMember(
                destinationMember: eq => eq.ExamTitle,
                memberOptions: opt => opt.MapFrom(eq => eq.Exam.Title))
                .ReverseMap();
            CreateMap<ExamQuestion, GetListExamQuestionResponse>()
                .ForMember(
                destinationMember: eq => eq.ExamTitle,
                memberOptions: opt => opt.MapFrom(eq => eq.Exam.Title))
                .ReverseMap();
            CreateMap<Paginate<ExamQuestion>, Paginate<GetListExamQuestionResponse>>().ReverseMap();
        }
    }
}
