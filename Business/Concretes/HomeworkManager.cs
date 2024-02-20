using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
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
    public class HomeworkManager : IHomeworkService
    {
        IMapper _mapper;
        IHomeworkDal _homeworkDal;
        public HomeworkManager(IMapper mapper, IHomeworkDal homeworkDal)
        {
            _mapper = mapper;
            _homeworkDal = homeworkDal;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest)
        {
            Homework homework = _mapper.Map<Homework>(createHomeworkRequest);
            var createdHomework = await _homeworkDal.AddAsync(homework);
            CreatedHomeworkResponse result = _mapper.Map<CreatedHomeworkResponse>(homework);
            return result;
        }

        [SecuredOperation("admin")]
        public Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId)
        {
            throw new NotImplementedException();
        }

        public Task<GetHomeworkResponse> GetByIdAsync(Guid homeworkId)
        {
            throw new NotImplementedException();
        }

        public async Task<Paginate<GetListHomeworkResponse>> GetListAsync()
        {
            var result = await _homeworkDal.GetListAsync();
            return _mapper.Map<Paginate<GetListHomeworkResponse>>(result);
        }

        [SecuredOperation("admin")]
        public Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest)
        {
            throw new NotImplementedException();
        }
    }
}
