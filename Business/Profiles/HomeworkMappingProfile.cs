using AutoMapper;
using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class HomeworkMappingProfile : Profile
    {
        public HomeworkMappingProfile()
        {
            CreateMap<Homework, CreateHomeworkRequest>().ReverseMap();
            CreateMap<Homework, UpdateHomeworkRequest>().ReverseMap();

            CreateMap<Homework, CreatedHomeworkResponse>().ReverseMap();
            CreateMap<Homework, UpdatedHomeworkResponse>().ReverseMap();
            CreateMap<Homework, DeletedHomeworkResponse>().ReverseMap();
            CreateMap<Homework, GetHomeworkResponse>().ReverseMap();



            CreateMap<Homework, GetListHomeworkResponse>().ReverseMap();
            CreateMap<Paginate<Homework>, Paginate<GetListHomeworkResponse>>().ReverseMap();
        }
    }
}
