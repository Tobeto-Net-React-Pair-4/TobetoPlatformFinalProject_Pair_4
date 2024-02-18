using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Responses;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Responses;
using Business.Dtos.SocialMediaAccount.Requests;
using Business.Dtos.SocialMediaAccount.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseLiveContentManager : ICourseLiveContentService
    {
        IMapper _mapper;
        ICourseLiveContentDal _courseLiveContentDal;

        public CourseLiveContentManager(IMapper mapper, ICourseLiveContentDal courseLiveContentDal)
        {
            _mapper = mapper;
            _courseLiveContentDal = courseLiveContentDal;
        }
        public async Task<CreatedCourseLiveContentResponse> AddAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest)
        {

            CourseLiveContent courseLiveContent = _mapper.Map<CourseLiveContent>(createCourseLiveContentRequest);
            var createdCourseLiveContent = await _courseLiveContentDal.AddAsync(courseLiveContent);
            CreatedCourseLiveContentResponse courseLiveContentResponse = _mapper.Map<CreatedCourseLiveContentResponse>(createdCourseLiveContent);
            return courseLiveContentResponse;
          
        }
        public async Task<DeletedCourseLiveContentResponse> DeleteAsync(DeleteCourseLiveContentRequest deleteCourseLiveContentRequest)
        {
            CourseLiveContent courseLiveContent = await _courseLiveContentDal.GetAsync(clc =>clc.CourseId == deleteCourseLiveContentRequest.CourseId && clc.LiveContentId == deleteCourseLiveContentRequest.LiveContentId);
            await _courseLiveContentDal.DeleteAsync(courseLiveContent);
            return _mapper.Map<DeletedCourseLiveContentResponse>(courseLiveContent);

        }
        public async Task<GetCourseLiveContentResponse> GetAsync(GetCourseLiveContentRequest courseLiveContentRequest)
        {
            CourseLiveContent courseLiveContent = await _courseLiveContentDal.GetAsync(cl => cl.CourseId == courseLiveContentRequest.CourseId && cl.LiveContentId == courseLiveContentRequest.LiveContentId);
            return _mapper.Map<GetCourseLiveContentResponse>(courseLiveContent);
        }

        public async Task<Paginate<GetListCourseLiveContentResponse>> GetListAsync()
        {
            var courseLiveContent = await _courseLiveContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseLiveContentResponse>>(courseLiveContent);
        }

        public async Task<Paginate<GetListLiveContentResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            var liveContentCourses = await _courseLiveContentDal
                .GetListAsync(clc => clc.CourseId == courseId, include: clc => clc.Include(clc => clc.LiveContent)
                .Include(clc => clc.LiveContent.Category)
                .Include(clc => clc.LiveContent.Like));
            return _mapper.Map<Paginate<GetListLiveContentResponse>>(liveContentCourses);

        }

        public async Task<UpdatedCourseLiveContentResponse> UpdateAsync(UpdateCourseLiveContentRequest updateCourseLiveContentRequest)
        {
            CourseLiveContent courseLiveContent = await GetAsync(cl => cl.CourseId == updateCourseLiveContentRequest.CourseId && cl.LiveContentId == updateCourseLiveContentRequest.LiveContentId);
            await _courseLiveContentDal.UpdateAsync(courseLiveContent);
            return _mapper.Map<UpdatedCourseLiveContentResponse>(updateCourseLiveContentRequest);
        }
    }
}