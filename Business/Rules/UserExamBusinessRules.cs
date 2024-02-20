using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.Exam.Responses;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class UserExamBusinessRules : BaseBusinessRules<UserExam>
    {
        IUserExamDal _userExamDal;
        IUserService _userService;
        IExamService _examService;
        public UserExamBusinessRules(IUserExamDal userExamDal, IExamService examService, IUserService userService) : base(userExamDal)
        {
            _userExamDal = userExamDal;
            _examService = examService;
            _userService = userService;
        }
        public async Task<UserExam> CheckIfUserExamExists(Guid examId, Guid userId)
        {
            UserExam userExam = await _userExamDal.GetAsync
                (ue => ue.ExamId == examId && ue.UserId == userId);
            if (userExam == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return userExam;
        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfExamExists(Guid examId)
        {
            GetByIdExamResponse exam = await _examService.GetByIdAsync(examId);
            if (exam == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
