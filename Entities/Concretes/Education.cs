using Core.Entities;
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
        public SelectList EducationalStatus { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public DateTime StartOfYear { get; set; }
        public DateTime GraduationYear { get; set; }

        //public InputCheckbox Continuing { get; set; }?
    }
}
