using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Category.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private IInstructorDal _instructorDal;
        private IMapper _mapper;
        private InstructorBusinessRules _instructorBusinessRules;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper, InstructorBusinessRules instructorBusinessRules)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
            _instructorBusinessRules = instructorBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest)
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

        [SecuredOperation("admin")]
        public async Task<DeletedInstructorResponse> DeleteAsync(Guid instructorId)
        {
            Instructor instructor = await _instructorBusinessRules.CheckIfExistsById(instructorId);

            await _instructorDal.DeleteAsync(instructor);
            return _mapper.Map<DeletedInstructorResponse>(instructor);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest)
        {
            Instructor instructor = await _instructorBusinessRules.CheckIfExistsById(updateInstructorRequest.Id);

            _mapper.Map(updateInstructorRequest, instructor);
            await _instructorDal.UpdateAsync(instructor);
            return _mapper.Map<UpdatedInstructorResponse>(instructor);
        }

        public async Task<GetByIdInstructorResponse> GetByIdAsync(Guid instructorId)
        {
            await _instructorBusinessRules.CheckIfExistsById(instructorId);

            Instructor instructor = await _instructorDal.GetAsync(p => p.Id == instructorId, include: c => c.Include(c => c.Courses));
            return _mapper.Map<GetByIdInstructorResponse>(instructor);
        }
    }
}
