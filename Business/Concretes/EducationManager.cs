using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class EducationManager : IEducationService
    {
        private IEducationDal _educationDal;
        private IMapper _mapper;
        private EducationBusinessRules _educationBusinessRules;
        public EducationManager(IEducationDal educationDal, IMapper mapper, EducationBusinessRules educationBusinessRules)
        {
            _educationDal = educationDal;
            _mapper = mapper;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest)
        {
            await _educationBusinessRules.CheckIfUserExists(createEducationRequest.UserId);

            Education education = _mapper.Map<Education>(createEducationRequest);
            var createdEducation = await _educationDal.AddAsync(education);
            CreatedEducationResponse result = _mapper.Map<CreatedEducationResponse>(education);
            return result;
        }

        public async Task<DeletedEducationResponse> DeleteAsync(Guid educationId)
        {
            await _educationBusinessRules.CheckIfExistsById(educationId);

            Education education = await _educationDal.GetAsync(p => p.Id == educationId);
            await _educationDal.DeleteAsync(education);
            return _mapper.Map<DeletedEducationResponse>(education);
        }

        public async Task<GetEducationResponse> GetByIdAsync(Guid educationId)
        {
            await _educationBusinessRules.CheckIfExistsById(educationId);

            var result = await _educationDal.GetAsync(e => e.Id == educationId);
            return _mapper.Map<GetEducationResponse>(result);
        }

        public async Task<Paginate<GetListEducationResponse>> GetListAsync()
        {
            var result = await _educationDal.GetListAsync();
            return _mapper.Map<Paginate<GetListEducationResponse>>(result);
        }


        public async Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest)
        {
            await _educationBusinessRules.CheckIfUserExists(updateEducationRequest.UserId);
            await _educationBusinessRules.CheckIfExistsById(updateEducationRequest.Id);

            Education education = await _educationDal.GetAsync
                (e => e.Id == updateEducationRequest.Id && e.UserId == updateEducationRequest.UserId);
            _mapper.Map(updateEducationRequest, education);
            education = await _educationDal.UpdateAsync(education);
            return _mapper.Map<UpdatedEducationResponse>(education);
        }
        public async Task<Paginate<GetListEducationResponse>> GetListByUserIdAsync(Guid userId)
        {
            await _educationBusinessRules.CheckIfUserExists(userId);

            var result = await _educationDal.GetListAsync(e => e.UserId == userId);
            return _mapper.Map<Paginate<GetListEducationResponse>>(result);
        }
    }
}
