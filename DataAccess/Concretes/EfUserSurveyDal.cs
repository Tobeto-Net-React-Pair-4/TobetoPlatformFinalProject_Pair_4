﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserSurveyDal : EfRepositoryBase<UserSurvey, Guid, TobetoContext>, IUserSurveyDal
    {
        public EfUserSurveyDal(TobetoContext context) : base(context)
        {
        }
    }
}
