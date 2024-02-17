using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.Appeal.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Rules;
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
    public class AppealManager : IAppealService
    {
        private IAppealDal _appealDal;
        private IMapper _mapper;
        private AppealBusinessRules _appealBusinessRules;
        public AppealManager(IAppealDal appealDal, IMapper mapper, AppealBusinessRules appealBusinessRules)
        {
            _appealDal = appealDal;
            _mapper = mapper;
            _appealBusinessRules = appealBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedAppealResponse> AddAsync(CreateAppealRequest createAppealRequest)
        {

            Appeal appeal = _mapper.Map<Appeal>(createAppealRequest);
            appeal.Id = Guid.NewGuid();

            Appeal createdAppeal = await _appealDal.AddAsync(appeal);
            return _mapper.Map<CreatedAppealResponse>(createdAppeal);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedAppealResponse> DeleteAsync(Guid appealId)
        {
            await _appealBusinessRules.CheckIfExistsById(appealId);

            Appeal appeal = await _appealDal.GetAsync(p => p.Id == appealId);
            await _appealDal.DeleteAsync(appeal);
            return _mapper.Map<DeletedAppealResponse>(appeal);
        }

        public async Task<Paginate<GetListAppealResponse>> GetListAsync()
        {
            var data = await _appealDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAppealResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedAppealResponse> UpdateAsync(UpdateAppealRequest updateAppealRequest)
        {
            await _appealBusinessRules.CheckIfExistsById(updateAppealRequest.Id);

            Appeal appeal = await _appealDal.GetAsync(p => p.Id == updateAppealRequest.Id);
            _mapper.Map(updateAppealRequest, appeal);
            await _appealDal.UpdateAsync(appeal);
            return _mapper.Map<UpdatedAppealResponse>(appeal);
        }
    }
}
