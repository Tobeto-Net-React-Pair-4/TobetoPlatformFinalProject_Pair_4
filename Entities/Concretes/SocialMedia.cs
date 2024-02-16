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
    public class SocialMedia : Entity<Guid>
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
