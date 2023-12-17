using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private IInstructorDal _instructorDal;
        private IMapper _mapper;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }
        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            instructor.Id = Guid.NewGuid();

            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

            return _mapper.Map<CreatedInstructorResponse>(createdInstructor);
        }

        public async Task<Paginate<GetListInstructorResponse>> GetListAsync()
        {
            var data = await _instructorDal.GetListAsync();
            return _mapper.Map<Paginate<GetListInstructorResponse>>(data);
        }
        public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
        {
            Instructor instructor = await _instructorDal.GetAsync(p => p.Id == deleteInstructorRequest.Id);
            await _instructorDal.DeleteAsync(instructor);
            return _mapper.Map<DeletedInstructorResponse>(instructor);
        }

        public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest)
        {
            Instructor instructor = await _instructorDal.GetAsync(p => p.Id == updateInstructorRequest.Id);
            _mapper.Map(updateInstructorRequest, instructor);
            await _instructorDal.UpdateAsync(instructor);
            return _mapper.Map<UpdatedInstructorResponse>(instructor);
        }
    }
}
