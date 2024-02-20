using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
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
    public class SessionManager : ISessionService
    {
        IMapper _mapper;
        ISessionDal _sessionDal;
        IInstructorSessionService _instructorSessionService;

        public SessionManager(IMapper mapper, ISessionDal sessionDal, IInstructorSessionService instructorSessionService)
        {
            _mapper = mapper;
            _sessionDal = sessionDal;
            _instructorSessionService = instructorSessionService;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
        {
            Session session = _mapper.Map<Session>(createSessionRequest);
            var createdSession = await _sessionDal.AddAsync(session);
            CreatedSessionResponse result = _mapper.Map<CreatedSessionResponse>(session);
            return result;
        }

        public async Task<CreatedInstructorSessionResponse> AssignSessionAsync(CreateInstructorSessionRequest createInstructorSessionRequest)
        {
            return await _instructorSessionService.AddAsync(createInstructorSessionRequest);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedSessionResponse> DeleteAsync(Guid sessionId)
        {
            Session session = await _sessionDal.GetAsync(p => p.Id == sessionId);
            await _sessionDal.DeleteAsync(session);
            return _mapper.Map<DeletedSessionResponse>(session);
        }

        public async Task<GetSessionResponse> GetByIdAsync(Guid sessionId)
        {
            var result = await _sessionDal.GetAsync(s => s.Id == sessionId);
            return _mapper.Map<GetSessionResponse>(result);
        }

        public async Task<Paginate<GetListSessionResponse>> GetListAsync()
        {
            var result = await _sessionDal.GetListAsync();
            return _mapper.Map<Paginate<GetListSessionResponse>>(result);
        }

        public async Task<Paginate<GetListSessionResponse>> GetListByInstructorIdAsync(Guid instructorId)
        {
            return await _instructorSessionService.GetListByInstructorIdAsync(instructorId);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
        {
            Session session = await _sessionDal.GetAsync(p => p.Id == updateSessionRequest.Id);
            _mapper.Map(updateSessionRequest, session);
            await _sessionDal.UpdateAsync(session);
            return _mapper.Map<UpdatedSessionResponse>(session);
        }
    }
}
