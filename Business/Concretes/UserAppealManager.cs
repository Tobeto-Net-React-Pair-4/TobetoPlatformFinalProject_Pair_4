using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Category.Responses;
using Business.Dtos.UserAppeal.Requests;
using Business.Dtos.UserAppeal.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class UserAppealManager : IUserAppealService
    {
        IMapper _mapper;
        IUserAppealDal _userAppealDal;
        public UserAppealManager(IMapper mapper, IUserAppealDal userAppealDal)
        {
            _mapper = mapper;
            _userAppealDal = userAppealDal;
        }
        public async Task<CreatedUserAppealResponse> AddAsync(CreateUserAppealRequest createUserAppealRequest)
        {
            UserAppeal userAppeal = _mapper.Map<UserAppeal>(createUserAppealRequest);

            var createdUserAppeal = await _userAppealDal.AddAsync(userAppeal);

            CreatedUserAppealResponse createdUserAppealResponse = _mapper.Map<CreatedUserAppealResponse>(createdUserAppeal);

            return createdUserAppealResponse;
        }

        public async Task<DeletedUserAppealResponse> DeleteAsync(DeleteUserAppealRequest deleteUserAppealRequest)
        {
            UserAppeal userAppeal = await _userAppealDal.GetAsync
                (p => p.UserId == deleteUserAppealRequest.UserId && p.AppealId == deleteUserAppealRequest.AppealId);
            await _userAppealDal.DeleteAsync(userAppeal);
            return _mapper.Map<DeletedUserAppealResponse>(userAppeal);
        }

        public async Task<GetUserAppealRequest> GetAsync(GetUserAppealRequest getUserAppealRequest)
        {
            UserAppeal userAppeal = await _userAppealDal.GetAsync
                (p => p.UserId == getUserAppealRequest.UserId && p.AppealId == getUserAppealRequest.AppealId);
            return _mapper.Map<GetUserAppealRequest>(userAppeal);
        }

        public async Task<Paginate<GetListUserAppealResponse>> GetListAsync()
        {
            var data = await _userAppealDal.GetListAsync(include: u => u.Include(u => u.User).Include(c => c.Appeal));


            return _mapper.Map<Paginate<GetListUserAppealResponse>>(data);
        }
    }
}
