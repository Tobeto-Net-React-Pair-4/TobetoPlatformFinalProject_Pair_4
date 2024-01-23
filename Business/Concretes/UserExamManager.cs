using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
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
        public UserExamManager(IUserExamDal userExamDal, IMapper mapper)
        {
            _userExamDal = userExamDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserExamResponse> AddAsync(CreateUserExamRequest createUserExamRequest)
        {
            UserExam userExam = _mapper.Map<UserExam>(createUserExamRequest);
            var createdUserExam = await _userExamDal.AddAsync(userExam);
            return _mapper.Map<CreatedUserExamResponse>(createdUserExam);
        }

        public async Task<DeletedUserExamResponse> DeleteAsync(DeleteUserExamRequest deleteUserExamRequest)
        {
            UserExam userExam = await _userExamDal.GetAsync
                (ue => ue.ExamId == deleteUserExamRequest.ExamId && ue.UserId == deleteUserExamRequest.UserId);
            _userExamDal.DeleteAsync(userExam);
            return _mapper.Map<DeletedUserExamResponse>(userExam);
        }

        public async Task<GetUserExamResponse> GetAsync(GetUserExamRequest getUserExamRequest)
        {
            UserExam userExam = await _userExamDal.GetAsync
                (ue => ue.ExamId == getUserExamRequest.ExamId && ue.UserId == getUserExamRequest.UserId,
                include: ue => ue.Include(u => u.User).Include(e => e.Exam));
            return _mapper.Map<GetUserExamResponse>(userExam);
        }

        public async Task<Paginate<GetListUserExamResponse>> GetListAsync()
        {
            var data = await _userExamDal.GetListAsync
                (include: ue => ue.Include(u => u.User).Include(e => e.Exam));
            return _mapper.Map<Paginate<GetListUserExamResponse>>(data);
        }
    }
}
