using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AnnouncementBusinessRules : BaseBusinessRules<Announcement>
    {
        IAnnouncementDal _announcementDal;
        public AnnouncementBusinessRules(IAnnouncementDal announcementDal) : base(announcementDal)
        {
            _announcementDal = announcementDal;
        }
    }
}
