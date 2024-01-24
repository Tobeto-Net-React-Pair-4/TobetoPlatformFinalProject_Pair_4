using Business.Dtos.Skill.Requests;
using Business.Dtos.Skill.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISkillService
    {
        Task<Paginate<GetListSkillResponse>> GetListAsync();
        Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest);
        Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest);
        Task<DeletedSkillResponse> DeleteAsync(DeleteSkillRequest deleteSkillRequest);
        Task<GetByIdSkillResponse> GetByIdAsync(GetByIdSkillRequest getByIdSkillRequest);
    }
}
