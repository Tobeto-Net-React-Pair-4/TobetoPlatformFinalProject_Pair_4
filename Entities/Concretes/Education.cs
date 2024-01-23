using Core.Entities.Concrete;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Education : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string EducationalDegree { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public DateTime StartOfYear { get; set; }
        public DateTime GraduationYear { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }
    }
}
