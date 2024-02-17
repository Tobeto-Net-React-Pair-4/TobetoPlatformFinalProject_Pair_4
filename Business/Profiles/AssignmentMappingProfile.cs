using AutoMapper;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<Assignment, CreateAssignmentRequest>().ReverseMap();
            CreateMap<Assignment, UpdateAssignmentRequest>().ReverseMap();

            CreateMap<Assignment, CreatedAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, UpdatedAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, DeletedAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, GetAssignmentResponse>().ReverseMap();

            CreateMap<Assignment, GetListAssignmentResponse>().ReverseMap();
            CreateMap<Paginate<Assignment>, Paginate<GetListAssignmentResponse>>().ReverseMap();
        }
    }
}
