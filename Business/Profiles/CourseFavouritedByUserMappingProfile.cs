using AutoMapper;
using Business.Dtos.CourseFavouritedByUser.Requests;
using Business.Dtos.CourseFavouritedByUser.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseFavouritedByUserMappingProfile : Profile
    {
        protected CourseFavouritedByUserMappingProfile()
        {
            CreateMap<CourseFavouritedByUser, CreateCourseFavouritedByUserRequest>().ReverseMap();
            CreateMap<CourseFavouritedByUser, UpdateCourseFavouritedByUserRequest>().ReverseMap();

            CreateMap<CourseFavouritedByUser, CreatedCourseFavouritedByUserResponse>().ReverseMap();
            CreateMap<CourseFavouritedByUser, UpdatedCourseFavouritedByUserResponse>().ReverseMap();
            CreateMap<CourseFavouritedByUser, DeletedCourseFavouritedByUserResponse>().ReverseMap();
            CreateMap<CourseFavouritedByUser, GetCourseFavouritedByUserResponse>().ReverseMap();

            CreateMap<CourseFavouritedByUser, GetListCourseFavouritedByUserResponse>().ReverseMap();
            CreateMap<Paginate<CourseFavouritedByUser>, Paginate<GetListCourseFavouritedByUserResponse>>().ReverseMap();
        }
    }
}
