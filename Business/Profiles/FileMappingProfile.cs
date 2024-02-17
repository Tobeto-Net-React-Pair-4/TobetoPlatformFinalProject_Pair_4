using AutoMapper;
using Business.Dtos.File.Requests;
using Business.Dtos.File.Responses;
using Core.DataAccess.Paging;
using File = Entities.Concretes.File;

namespace Business.Profiles
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<File, CreateFileRequest>().ReverseMap();
            CreateMap<File, UpdateFileRequest>().ReverseMap();

            CreateMap<File, CreatedFileResponse>().ReverseMap();
            CreateMap<File, UpdatedFileResponse>().ReverseMap();
            CreateMap<File, DeletedFileResponse>().ReverseMap();
            CreateMap<File, GetFileResponse>().ReverseMap();




            CreateMap<File, GetListFileResponse>().ReverseMap();
            CreateMap<Paginate<File>, Paginate<GetListFileResponse>>().ReverseMap();
        }
    }
}
