using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class UserSurvey : Entity<Guid>
    {
        public Guid SurveyId { get; set; }
        public Guid UserId { get; set; }
        public Survey Survey { get; set; }
        public User User { get; set; }
    }
}
