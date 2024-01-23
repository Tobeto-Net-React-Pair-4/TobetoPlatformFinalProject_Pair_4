using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, DeleteUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, GetByIdUserRequest>().ReverseMap();

            CreateMap<User, CreatedUserResponse>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();
            CreateMap<User, DeletedUserResponse>().ReverseMap();
            CreateMap<User, GetUserResponse>().ReverseMap();
            CreateMap<User, GetListUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>()
                //.ForMember(
                //destinationMember: b => b.Courses, 
                //memberOptions: opt => opt.MapFrom(uc => uc.UserCourses)
                //)
                .ReverseMap();
            CreateMap<GetUserResponse, UserLoginResponse>().ReverseMap();
            CreateMap<CreatedUserResponse, UserRegisterResponse>().ReverseMap();

            CreateMap<User, UserRegisterRequest>().ReverseMap().ForMember(u => u.PasswordHash, opt => opt.MapFrom(r => r.passwordHash))
                .ForMember(u => u.PasswordSalt, opt => opt.MapFrom(r => r.passwordSalt));

            CreateMap<Paginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
        }
    }
}
