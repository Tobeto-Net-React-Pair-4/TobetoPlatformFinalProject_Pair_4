using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IPersonalInfoService
    {
        Task<CreatedPersonalInfoResponse> AddAsync(CreatePersonalInfoRequest createPersonalInfoRequest);
        Task<UpdatedPersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest updatePersonalInfoRequest);
        Task<DeletedPersonalInfoResponse> DeleteAsync(DeletePersonalInfoRequest deletePersonalInfoRequest);
        Task<GetPersonalInfoResponse> GetByUserIdAsync(GetPersonalInfoRequest getPersonalInfoRequest);
        Task<GetPersonalInfoResponse> GetByIdAsync(GetPersonalInfoRequest getPersonalInfoRequest);
        Task<Paginate<GetListPersonalInfoResponse>> GetListAsync();
    }
}
