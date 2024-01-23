using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Survey:Entity<Guid>
    {
        public string Title { get; set; }//Anket basligi
        public string Description { get; set; }//Anket aciklamasi
        public string Url { get; set; } // Anket url

        public ICollection<UserSurvey> UserSurveys { get; set; }

        
        
    }
}

