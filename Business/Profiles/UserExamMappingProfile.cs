using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class UserExamMappingProfile : Profile
    {
        public UserExamMappingProfile()
        {
            CreateMap<UserExam, CreateUserExamRequest>().ReverseMap();
            CreateMap<UserExam, DeleteUserExamRequest>().ReverseMap();
            CreateMap<UserExam, GetUserExamRequest>().ReverseMap();

            CreateMap<UserExam, CreatedUserExamResponse>().ReverseMap();
            CreateMap<UserExam, DeletedUserExamResponse>().ReverseMap();
            CreateMap<UserExam, GetUserExamResponse>()
                .ForMember(
                destinationMember: ue => ue.ExamTitle,
                memberOptions: opt => opt.MapFrom(ue => ue.Exam.Title))
                .ForMember(
                destinationMember: ue => ue.UserEmail,
                memberOptions: opt => opt.MapFrom(ue => ue.User.Email))
                .ReverseMap();
            CreateMap<UserExam, GetListUserExamResponse>()
                .ForMember(
                destinationMember: ue => ue.ExamTitle,
                memberOptions: opt => opt.MapFrom(ue => ue.Exam.Title))
                .ForMember(
                destinationMember: ue => ue.UserEmail,
                memberOptions: opt => opt.MapFrom(ue => ue.User.Email))
                .ReverseMap();
            CreateMap<Paginate<UserExam>, Paginate<GetListUserExamResponse>>().ReverseMap();
        }
    }
}
