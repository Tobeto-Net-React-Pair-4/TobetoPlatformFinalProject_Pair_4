using Business.Abstracts;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concretes.File;

namespace Business.Rules
{
    public class FileBusinessRules : BaseBusinessRules<File>
    {
        IFileDal _fileDal;
        IUserService _userService;
        IAssignmentService _assignmentService;
        public FileBusinessRules(IFileDal fileDal, IUserService userService, IAssignmentService assignmentService) : base(fileDal)
        {
            _fileDal = fileDal;
            _userService = userService;
            _assignmentService = assignmentService;

        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfAssignmentExists(Guid assignmentId)
        {
            GetAssignmentResponse assignment = await _assignmentService.GetByIdAsync(assignmentId);
            if (assignment == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
