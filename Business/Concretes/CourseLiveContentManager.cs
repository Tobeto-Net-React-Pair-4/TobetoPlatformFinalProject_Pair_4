using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
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
using Business.Rules;
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
        CourseLiveContentBusinessRules _courseLiveContentBusinessRules;

        public CourseLiveContentManager
            (IMapper mapper, ICourseLiveContentDal courseLiveContentDal, CourseLiveContentBusinessRules courseLiveContentBusinessRules)
        {
            _mapper = mapper;
            _courseLiveContentDal = courseLiveContentDal;
            _courseLiveContentBusinessRules = courseLiveContentBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCourseLiveContentResponse> AddAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest)
        {
            await _courseLiveContentBusinessRules.CheckIfCourseExists(createCourseLiveContentRequest.CourseId);
            await _courseLiveContentBusinessRules.CheckIfLiveContentExists(createCourseLiveContentRequest.LiveContentId);

            CourseLiveContent courseLiveContent = _mapper.Map<CourseLiveContent>(createCourseLiveContentRequest);
            var createdCourseLiveContent = await _courseLiveContentDal.AddAsync(courseLiveContent);
            CreatedCourseLiveContentResponse courseLiveContentResponse = _mapper.Map<CreatedCourseLiveContentResponse>(createdCourseLiveContent);
            return courseLiveContentResponse;
          
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCourseLiveContentResponse> DeleteAsync(DeleteCourseLiveContentRequest deleteCourseLiveContentRequest)
        {
            CourseLiveContent courseLiveContent = await _courseLiveContentBusinessRules.CheckIfCourseLiveContentExists
                (deleteCourseLiveContentRequest.CourseId, deleteCourseLiveContentRequest.LiveContentId);

            await _courseLiveContentDal.DeleteAsync(courseLiveContent);
            return _mapper.Map<DeletedCourseLiveContentResponse>(courseLiveContent);
        }

        public async Task<Paginate<GetListCourseLiveContentResponse>> GetListAsync()
        {
            var courseLiveContent = await _courseLiveContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseLiveContentResponse>>(courseLiveContent);
        }

        public async Task<Paginate<GetListLiveContentResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            await _courseLiveContentBusinessRules.CheckIfCourseExists(courseId);

            var liveContentCourses = await _courseLiveContentDal
                .GetListAsync(clc => clc.CourseId == courseId, include: clc => clc.Include(clc => clc.LiveContent)
                .Include(clc => clc.LiveContent.Category)
                .Include(clc => clc.LiveContent.Like));
            return _mapper.Map<Paginate<GetListLiveContentResponse>>(liveContentCourses);
        }
    }
}