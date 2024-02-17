using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.LiveContent.Responses
{
    public class GetLiveContentResponse
    {
        public Guid Id { get; set; }
        public Guid LikeId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
