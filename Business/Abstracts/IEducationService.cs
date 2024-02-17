using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEducationService
    {
        Task<Paginate<GetListEducationResponse>> GetListAsync();
        Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest);
        Task<DeletedEducationResponse> DeleteAsync(Guid educationId);
        Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest);
        Task<GetEducationResponse> GetByIdAsync(Guid educationId);

    }
}
