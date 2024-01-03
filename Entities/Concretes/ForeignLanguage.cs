using Core.Entities;
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
        public SelectList LanguageList { get; set; }
        public SelectList LanguageLevel { get; set; }
    }
}
