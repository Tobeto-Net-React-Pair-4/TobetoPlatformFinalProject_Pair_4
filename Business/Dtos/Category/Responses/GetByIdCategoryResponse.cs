using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Course.Responses;
using Entities.Concretes;

namespace Business.Dtos.Category.Responses
{
    public class GetByIdCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetByIdCourseResponse> Courses { get; set; }
    }
}
