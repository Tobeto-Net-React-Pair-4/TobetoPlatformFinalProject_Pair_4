using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Category.Requests;
using Business.Dtos.Category.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, DeleteCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category, GetByIdCategoryRequest>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();
            CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

            CreateMap<Category, GetListCategoryResponse>().ReverseMap();
            CreateMap<Category, GetByIdCategoryResponse>()
                .ForMember(destinationMember: c => c.Courses, memberOptions: opt => opt.MapFrom(c => c.Courses))
                //.ForMember(destinationMember: c => c.CourseName, memberOptions: opt => opt.MapFrom(c => c.Courses.FirstOrDefault(co => co.CategoryId == c.Id).Name))
                //.ForMember(destinationMember: c => c.Producer, memberOptions: opt => opt.MapFrom(c => c.Courses.FirstOrDefault(co => co.CategoryId == c.Id).Producer))
                //.ForMember(destinationMember: c => c., memberOptions: opt => opt.MapFrom(c => c.Courses.FirstOrDefault(co => co.CategoryId == c.Id).Name))
                .ReverseMap();

            CreateMap<Paginate<Category>, Paginate<GetListCategoryResponse>>().ReverseMap();
        }
    }
}
