using Business.Dtos.Skill.Responses;
using Business.Dtos.UserSkill.Requests;
using Business.Dtos.UserSkill.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserSkillService
    {
        Task<Paginate<GetUserSkillResponse>> GetListAsync();
        Task<CreatedUserSkillResponse> AddAsync(CreateUserSkillRequest createUserSkillRequest);
        Task<DeletedUserSkillResponse> DeleteAsync(DeleteUserSkillRequest deleteUserSkillRequest);
        Task<Paginate<GetListSkillResponse>> GetListByUserIdAsync(Guid userId);

    }
}
