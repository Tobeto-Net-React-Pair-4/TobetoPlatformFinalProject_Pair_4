using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Favourite.Responses
{
    public class GetFavouriteResponse
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
    }
}
