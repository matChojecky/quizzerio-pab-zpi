using Quizerio.Domain.Quizz;

namespace Quizerio.Domain.Quiz
{
    public class QuizzFacade : IQuizzFacade, IQuestionFacade
    {
        private IQuestionService _questionService;

        public QuizzFacade(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        public void ApproveQuestion(Guid questionId)
        {
            _questionService.ChangeQuestionStatus(questionId, QuestionStatus.Approved);
        }

        public void RejectQuestion(Guid questionId, string reason)
        {
            _questionService.ChangeQuestionStatus(questionId, QuestionStatus.Rejected);
        }

        GetQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        List<Quizz.Question> IQuestionFacade.GetQuestions()
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(Quizz.Question question)
        {
            throw new NotImplementedException();
        }

        public void AddQuestions(List<Quizz.Question> questions)
        {
            throw new NotImplementedException();
        }

        public Quizz.Question GetQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public List<Quizz.Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(Quizz.Question question)
        {
            throw new NotImplementedException();
        }

        public void AddQuestions(List<Quizz.Question> questions)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(Quizz.Question question)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(Quizz.Question question)
        {
            throw new NotImplementedException();
        }
    }
}