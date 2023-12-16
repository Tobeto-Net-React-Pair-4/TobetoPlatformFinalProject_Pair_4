using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

            CreateMap<Instructor, GetListedInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>().ReverseMap();
        }
    }
}
