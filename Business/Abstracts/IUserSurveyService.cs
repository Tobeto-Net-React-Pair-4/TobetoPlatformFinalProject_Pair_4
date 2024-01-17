using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Dtos.UserSurvey.Requests;
using Business.Dtos.UserSurvey.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserSurveyService
    {
        Task<Paginate<GetListUserSurveyResponse>> GetListAsync();
        Task<CreatedUserSurveyResponse> AddAsync(CreateUserSurveyRequest createUserSurveyRequest);
        Task<DeletedUserSurveyResponse> Delete(DeleteUserSurveyRequest deleteUserSurveyRequest);
    }
}
