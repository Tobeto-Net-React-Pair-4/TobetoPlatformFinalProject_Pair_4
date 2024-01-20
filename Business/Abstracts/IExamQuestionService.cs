using Business.Dtos.ExamQuestion.Requests;
using Business.Dtos.ExamQuestion.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IExamQuestionService
    {
        Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest);
        Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest);
        Task<DeletedExamQuestionResponse> DeleteAsync(DeleteExamQuestionRequest deleteExamQuestionRequest);
        Task<GetByIdExamQuestionResponse> GetByIdAsync(GetByIdExamQuestionRequest getByIdExamQuestionRequest);
        Task<Paginate<GetListExamQuestionResponse>> GetListAsync();
    }

}
