using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.QuestionAnswer.Responses
{
    public class CreatedQuestionAnswerResponse
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
