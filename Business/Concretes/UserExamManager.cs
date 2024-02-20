using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Exam.Responses;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class UserExamManager : IUserExamService
    {
        private IUserExamDal _userExamDal;
        private IMapper _mapper;
        private UserExamBusinessRules _userExamBusinessRules;
        public UserExamManager(IUserExamDal userExamDal, IMapper mapper, UserExamBusinessRules userExamBusinessRules)
        {
            _userExamDal = userExamDal;
            _mapper = mapper;
            _userExamBusinessRules = userExamBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedUserExamResponse> AddAsync(CreateUserExamRequest createUserExamRequest)
        {
            await _userExamBusinessRules.CheckIfExamExists(createUserExamRequest.ExamId);
            await _userExamBusinessRules.CheckIfUserExists(createUserExamRequest.UserId);

            UserExam userExam = _mapper.Map<UserExam>(createUserExamRequest);
            var createdUserExam = await _userExamDal.AddAsync(userExam);
            return _mapper.Map<CreatedUserExamResponse>(createdUserExam);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedUserExamResponse> DeleteAsync(DeleteUserExamRequest deleteUserExamRequest)
        {
            UserExam userExam = await _userExamBusinessRules.CheckIfUserExamExists
                (deleteUserExamRequest.ExamId, deleteUserExamRequest.UserId);

            _userExamDal.DeleteAsync(userExam);
            return _mapper.Map<DeletedUserExamResponse>(userExam);
        }

        public async Task<Paginate<GetListUserExamResponse>> GetListAsync()
        {
            var data = await _userExamDal.GetListAsync
                (include: ue => ue.Include(u => u.User).Include(e => e.Exam));
            return _mapper.Map<Paginate<GetListUserExamResponse>>(data);
        }

        public async Task<Paginate<GetListExamResponse>> GetListByUserIdAsync(Guid userId)
        {
            await _userExamBusinessRules.CheckIfUserExists(userId);

            var userExams = await _userExamDal.GetListAsync(ue => ue.UserId == userId);
            return _mapper.Map<Paginate<GetListExamResponse>>(userExams);
        }
    }
}
