using Business.Dtos.QuestionAnswer.Requests;
using Business.Dtos.QuestionAnswer.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IQuestionAnswerService
    {
        Task<CreatedQuestionAnswerResponse> AddAsync(CreateQuestionAnswerRequest createQuestionAnswerRequest);
        Task<UpdatedQuestionAnswerResponse> UpdateAsync(UpdateQuestionAnswerRequest updateQuestionAnswerRequest);
        Task<DeletedQuestionAnswerResponse> DeleteAsync(Guid questionAnswerId);
        Task<GetByIdQuestionAnswerResponse> GetByIdAsync(Guid questionAnswerId);
        Task<Paginate<GetListQuestionAnswerResponse>> GetListAsync();
    }
}
