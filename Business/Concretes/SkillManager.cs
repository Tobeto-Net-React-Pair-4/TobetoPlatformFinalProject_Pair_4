using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Skill.Requests;
using Business.Dtos.Skill.Responses;
using Business.Dtos.Skill.Requests;
using Business.Dtos.Skill.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
        public class SkillManager : ISkillService
        {
            private ISkillDal _SkillDal;
            private IMapper _mapper;
            public SkillManager(ISkillDal SkillDal, IMapper mapper)
            {
                _SkillDal = SkillDal;
                _mapper = mapper;
            }
            public async Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest)
            {
                Skill Skill = _mapper.Map<Skill>(createSkillRequest);
                Skill.Id = Guid.NewGuid();

                Skill createdSkill = await _SkillDal.AddAsync(Skill);

                return _mapper.Map<CreatedSkillResponse>(createdSkill);
            }

            public async Task<Paginate<GetListSkillResponse>> GetListAsync()
            {
                var data = await _SkillDal.GetListAsync();
                return _mapper.Map<Paginate<GetListSkillResponse>>(data);
            }
            public async Task<DeletedSkillResponse> DeleteAsync(DeleteSkillRequest deleteSkillRequest)
            {
                Skill Skill = await _SkillDal.GetAsync(p => p.Id == deleteSkillRequest.Id);
                await _SkillDal.DeleteAsync(Skill);
                return _mapper.Map<DeletedSkillResponse>(Skill);
            }

            public async Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest)
            {
                Skill Skill = await _SkillDal.GetAsync(p => p.Id == updateSkillRequest.Id);
                _mapper.Map(updateSkillRequest, Skill);
                await _SkillDal.UpdateAsync(Skill);
                return _mapper.Map<UpdatedSkillResponse>(Skill);
            }

            public async Task<GetByIdSkillResponse> GetByIdAsync(GetByIdSkillRequest getByIdSkillRequest)
            {
                Skill Skill = await _SkillDal.GetAsync(p => p.Id == getByIdSkillRequest.Id);

                return _mapper.Map<GetByIdSkillResponse>(Skill);
            }
        }
    }
