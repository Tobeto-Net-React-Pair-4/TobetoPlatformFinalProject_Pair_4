using AutoMapper;
using Business.Dtos.File.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class HomeworkFileMappingProfile : Profile
    {
        public HomeworkFileMappingProfile()
        {
            CreateMap<CreateHomeworkFileRequest, HomeworkFile>().ReverseMap();
            CreateMap<HomeworkFile, CreatedHomeworkFileResponse>().ReverseMap();

            CreateMap<DeleteHomeworkFileRequest, HomeworkFile>().ReverseMap();
            CreateMap<HomeworkFile, DeletedHomeworkFileResponse>().ReverseMap();

            CreateMap<Paginate<HomeworkFile>, Paginate<GetListHomeworkFileResponse>>().ReverseMap();
            CreateMap<HomeworkFile, GetListHomeworkFileResponse>().ReverseMap();

            CreateMap<HomeworkFile, GetListFileResponse>()
                .IncludeMembers(hm => hm.File)
                .ForMember(destinationMember: lr => lr.Id, memberOptions: opt => opt.MapFrom(hf => hf.FileId))
                .ReverseMap();

            //CreateMap<Paginate<HomeworkFile>, Paginate<GetListFileResponse>>().ReverseMap();
        }
    }
}
