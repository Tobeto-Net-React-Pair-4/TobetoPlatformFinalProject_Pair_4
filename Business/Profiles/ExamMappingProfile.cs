﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Exam.Requests;
using Business.Dtos.Exam.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, CreateExamRequest>().ReverseMap();
            CreateMap<Exam, UpdateExamRequest>().ReverseMap();

            CreateMap<Exam, CreatedExamResponse>().ReverseMap();
            CreateMap<Exam, DeletedExamResponse>().ReverseMap();
            CreateMap<Exam, GetByIdExamResponse>().ReverseMap();
            CreateMap<Exam, UpdatedExamResponse>().ReverseMap();

            CreateMap<Exam, GetListExamResponse>().ReverseMap();
            CreateMap<Paginate<Exam>, Paginate<GetListExamResponse>>().ReverseMap();
        }
    }
}
