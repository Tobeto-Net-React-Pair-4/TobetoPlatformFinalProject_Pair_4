using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SurveyManager : ISurveyService
    {
        private ISurveyDal _surveyDal;
        private IMapper _mapper;
        public SurveyManager(ISurveyDal surveyDal,IMapper mapper)
        {
            _surveyDal = surveyDal;
            _mapper = mapper;
        }
        public async Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest)
        {
            Survey survey = _mapper.Map<Survey>(createSurveyRequest);
            survey.Id = Guid.NewGuid();
            Survey createdSurvey = await _surveyDal.AddAsync(survey);

            return _mapper.Map<CreatedSurveyResponse>(createdSurvey);
        }

        public async Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest)
        {
            Survey survey = await _surveyDal.GetAsync(p => p.Id == deleteSurveyRequest.Id);
            await _surveyDal.DeleteAsync(survey);
            return _mapper.Map<DeletedSurveyResponse>(survey);
        }

        public async Task<Paginate<GetListSurveyResponse>> GetListAsync()
        {
            var data = await _surveyDal.GetListAsync();
            return _mapper.Map<Paginate<GetListSurveyResponse>>(data);
        }

        public async Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
        {
            Survey survey = await _surveyDal.GetAsync(p => p.Id == updateSurveyRequest.Id);
            _mapper.Map(updateSurveyRequest, survey);
            await _surveyDal.UpdateAsync(survey);
            return _mapper.Map<UpdatedSurveyResponse>(survey);
        }
       
    }
}
