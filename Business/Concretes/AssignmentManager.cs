using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{

    public class AssignmentManager : IAssignmentService
    {
        private IAssignmentDal _assignmentDal;
        private IMapper _mapper;
        public AssignmentManager(IAssignmentDal assignmentDal, IMapper mapper)
        {
            _assignmentDal = assignmentDal;
            _mapper = mapper;
        }
        public async Task<CreatedAssignmentResponse> AddAsync(CreateAssignmentRequest createAssignmentRequest)
        {

            Assignment assignment = _mapper.Map<Assignment>(createAssignmentRequest);
            assignment.Id = Guid.NewGuid();

            Assignment createdAssignment = await _assignmentDal.AddAsync(assignment);
            return _mapper.Map<CreatedAssignmentResponse>(createdAssignment);
        }

        public async Task<DeletedAssignmentResponse> DeleteAsync(Guid Id)
        {

            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == Id);
            await _assignmentDal.DeleteAsync(assignment);
            return _mapper.Map<DeletedAssignmentResponse>(assignment);
        }


        public async Task<Paginate<GetListAssignmentResponse>> GetListAsync()
        {
            var data = await _assignmentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAssignmentResponse>>(data);
        }

        public async Task<UpdatedAssignmentResponse> UpdateAsync(UpdateAssignmentRequest updateAssignmentRequest)
        {
            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == updateAssignmentRequest.Id);
            _mapper.Map(updateAssignmentRequest, assignment);
            await _assignmentDal.UpdateAsync(assignment);
            return _mapper.Map<UpdatedAssignmentResponse>(assignment);
        }
        public async Task<GetAssignmentResponse> GetByIdAsync(Guid Id)
        {
            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetAssignmentResponse>(assignment);
        }
    }
}

