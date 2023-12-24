using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Business.Dtos.User.Responses;
using Business.Dtos.UserSurvey.Requests;
using Business.Dtos.UserSurvey.Responses;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class UserSurveyManager:IUserSurveyService
    {
         IUserSurveyDal _userSurveyDal;
         IMapper _mapper;

        public UserSurveyManager(IUserSurveyDal userSurveyDal, IMapper mapper)
        {
            _userSurveyDal = userSurveyDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserSurveyResponse> AddAsync(CreateUserSurveyRequest createUserSurveyRequest)
        {
            UserSurvey userSurvey = _mapper.Map<UserSurvey>(createUserSurveyRequest);
            var createdUserSurvey = await _userSurveyDal.AddAsync(userSurvey);
            CreatedUserSurveyResponse  createdUserSurveyResponse = _mapper.Map<CreatedUserSurveyResponse>(createdUserSurvey);
            return createdUserSurveyResponse;
        }

        public async Task<DeletedUserSurveyResponse> Delete(DeleteUserSurveyRequest deleteUserSurveyRequest)
        {
            UserSurvey userSurvey = await _userSurveyDal.GetAsync(predicate: p => p.SurveyId == deleteUserSurveyRequest.SurveyId);
            await _userSurveyDal.DeleteAsync(userSurvey);
            return _mapper.Map<DeletedUserSurveyResponse>(userSurvey);

        }

        public async Task<Paginate<GetListUserSurveyResponse>> GetListAsync()
        {

            var data = await _userSurveyDal.GetListAsync(include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListUserSurveyResponse>>(data);
        }

    }
}
