using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISurveyService
    {
        Task<Paginate<GetListSurveyResponse>> GetListAsync();
        Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest);
        Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest);
        Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest);
    }
}
