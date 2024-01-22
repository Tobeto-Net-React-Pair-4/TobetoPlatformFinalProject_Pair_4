using Core.Entities.Concrete;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ForeignLanguage : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string LanguageList { get; set; }
        public string LanguageLevel { get; set; }
        public User User { get; set; }
    }
}
