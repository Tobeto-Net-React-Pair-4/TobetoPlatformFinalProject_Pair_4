using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{

    public class AssignmentManager : IAssignmentService
    {
        private IAssignmentDal _assignmentDal;
        private IMapper _mapper;
        private AssignmentBusinessRules _assignmentBusinessRules;
        public AssignmentManager(IAssignmentDal assignmentDal, IMapper mapper, AssignmentBusinessRules assignmentBusinessRules)
        {
            _assignmentDal = assignmentDal;
            _mapper = mapper;
            _assignmentBusinessRules = assignmentBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedAssignmentResponse> AddAsync(CreateAssignmentRequest createAssignmentRequest)
        {
            await _assignmentBusinessRules.CheckIfCourseExists(createAssignmentRequest.CourseId);

            Assignment assignment = _mapper.Map<Assignment>(createAssignmentRequest);
            assignment.Id = Guid.NewGuid();

            Assignment createdAssignment = await _assignmentDal.AddAsync(assignment);
            return _mapper.Map<CreatedAssignmentResponse>(createdAssignment);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedAssignmentResponse> DeleteAsync(Guid assignmentId)
        {
            await _assignmentBusinessRules.CheckIfExistsById(assignmentId);

            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == assignmentId);
            await _assignmentDal.DeleteAsync(assignment);
            return _mapper.Map<DeletedAssignmentResponse>(assignment);
        }

        public async Task<Paginate<GetListAssignmentResponse>> GetListAsync()
        {
            var data = await _assignmentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAssignmentResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedAssignmentResponse> UpdateAsync(UpdateAssignmentRequest updateAssignmentRequest)
        {
            await _assignmentBusinessRules.CheckIfCourseExists(updateAssignmentRequest.CourseId);
            await _assignmentBusinessRules.CheckIfExistsById(updateAssignmentRequest.Id);

            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == updateAssignmentRequest.Id);
            _mapper.Map(updateAssignmentRequest, assignment);
            await _assignmentDal.UpdateAsync(assignment);
            return _mapper.Map<UpdatedAssignmentResponse>(assignment);
        }
        public async Task<GetAssignmentResponse> GetByIdAsync(Guid assignmentId)
        {
            await _assignmentBusinessRules.CheckIfExistsById(assignmentId);

            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == assignmentId);

            return _mapper.Map<GetAssignmentResponse>(assignment);
        }
    }
}

