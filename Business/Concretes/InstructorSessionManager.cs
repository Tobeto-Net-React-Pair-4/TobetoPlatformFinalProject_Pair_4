using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorSessionManager : IInstructorSessionService
    {
        IInstructorSessionDal _instructorSessionDal;
        IMapper _mapper;
        public InstructorSessionManager(IInstructorSessionDal instructorSessionDal, IMapper mapper)
        {
            _instructorSessionDal = instructorSessionDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorSessionResponse> AddAsync(CreateInstructorSessionRequest createInstructorSessionRequest)
        {
            InstructorSession instructorSession = _mapper.Map<InstructorSession>(createInstructorSessionRequest);
            var createdInstructorSession = await _instructorSessionDal.AddAsync(instructorSession);
            CreatedInstructorSessionResponse createdInstructorSessionResponse = _mapper.Map<CreatedInstructorSessionResponse>(createdInstructorSession);
            return createdInstructorSessionResponse;
        }

        public async Task<DeletedInstructorSessionResponse> DeleteAsync(DeleteInstructorSessionRequest deleteInstructorSessionRequest)
        {
            InstructorSession instructorSession = await _instructorSessionDal.GetAsync(uc => uc.InstructorId == deleteInstructorSessionRequest.InstructorId);
            await _instructorSessionDal.DeleteAsync(instructorSession);
            return _mapper.Map<DeletedInstructorSessionResponse>(instructorSession);
        }

        public async Task<Paginate<GetListInstructorSessionResponse>> GetListAsync()
        {
            var data = await _instructorSessionDal.GetListAsync(include: uc => uc.Include(uc => uc.Instructor).Include(uc => uc.Session));

            return _mapper.Map<Paginate<GetListInstructorSessionResponse>>(data);
        }

        public async Task<Paginate<GetListSessionResponse>> GetListByInstructorIdAsync(Guid instructorId)
        {
            var data = await _instructorSessionDal.GetListAsync(uc => uc.InstructorId == instructorId,
                include: uc => uc.Include(uc => uc.Session));
            return _mapper.Map<Paginate<GetListSessionResponse>>(data);
        }

    }
}
