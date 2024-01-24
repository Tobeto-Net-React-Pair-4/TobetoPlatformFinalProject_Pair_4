using AutoMapper;
using Business.Abstracts;
using Business.Dtos.UserSkill.Requests;
using Business.Dtos.UserSkill.Responses;
using Business.Dtos.UserSkill.Requests;
using Business.Dtos.UserSkill.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.UserSkill.Responses;
using DataAccess.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class UserSkillManager : IUserSkillService
    {
        IMapper _mapper;
        IUserSkillDal _userSkillDal;
        public UserSkillManager(IMapper mapper, IUserSkillDal userSkillDal)
        {
            _mapper = mapper;
            _userSkillDal = userSkillDal;
        }

        public async Task<CreatedUserSkillResponse> AddAsync(CreateUserSkillRequest createUserSkillRequest)
        {
            UserSkill userSkill = _mapper.Map<UserSkill>(createUserSkillRequest);

            var createdUserSkill = await _userSkillDal.AddAsync(userSkill);

            CreatedUserSkillResponse createdUserSkillResponse = _mapper.Map<CreatedUserSkillResponse>(createdUserSkill);

            return createdUserSkillResponse;
        }

        public async Task<DeletedUserSkillResponse> DeleteAsync(DeleteUserSkillRequest deleteUserSkillRequest)
        {
            UserSkill userSkill = await _userSkillDal.GetAsync
                (p => p.UserId == deleteUserSkillRequest.UserId && p.SkillId == deleteUserSkillRequest.SkillId);
            await _userSkillDal.DeleteAsync(userSkill);
            return _mapper.Map<DeletedUserSkillResponse>(userSkill);
        }

        public async Task<Paginate<GetUserSkillResponse>> GetListAsync()
        {
            var data = await _userSkillDal.GetListAsync(include: u => u.Include(u => u.User).Include(c => c.Skill));

            return _mapper.Map<Paginate<GetUserSkillResponse>>(data);
        }
    }
}
