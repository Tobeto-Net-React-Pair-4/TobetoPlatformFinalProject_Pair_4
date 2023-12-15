using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Category.Requests;
using Business.Dtos.Category.Response;
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
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();
            CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

            CreateMap<Category, GetListedCategoryResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetListedCategoryResponse>>().ReverseMap();
        }
    }
}
