using Quizerio.Application;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuizzFacade : IQuizzFacade
    {
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly IQuestionService _questionService;
        private readonly IQuizGameService _quizGameService;
        private readonly IQuizRepository _quizRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuizzFacade(
            IUnitOfWork unitOfWork,
            IQuestionService questionService,
            IQuestionCategoryRepository questionCategoryRepository, IQuizGameService quizGameService,
            IQuizRepository quizRepository)
        {
            _questionService = questionService;
            _questionCategoryRepository = questionCategoryRepository;
            _quizGameService = quizGameService;
            _quizRepository = quizRepository;
            _unitOfWork = unitOfWork;
        }


        public void ApproveQuestion(ApproveQuestionCommand command)
        {
            _questionService.ChangeQuestionStatus(command);
            _unitOfWork.Commit();
        }

        public void RejectQuestion(RejectQuestionCommand command)
        {
            _questionService.ChangeQuestionStatus(command);
            // TODO: send email to submitting user

            _unitOfWork.Commit();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionService.GetQuestion(query);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            return _questionService.GetQuestions(query);
        }

        public void AddQuestion(CreateQuestionCommand command)
        {
            _questionService.AddQuestion(command);
            _unitOfWork.Commit();
        }


        public void DeleteQuestion(DeleteQuestionCommand command)
        {
            _questionService.DeleteQuestion(command);
        }

        public void EditQuestion(UpdateQuestionCommand command)
        {
            _questionService.UpdateQuestion(command);

            _unitOfWork.Commit();
        }

        public void AddQuestionCategory(AddQuestionCategoryCommand command)
        {
            var category = new QuestionCategory(
                command.Name,
                Guid.NewGuid()
            );

            _questionCategoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public List<QuestionCategory> GetQuestionCategories()
        {
            return _questionCategoryRepository.GetAll();
        }

        public void CreateQuiz(CreateQuizCommand command)
        {
            var questions = new List<Question>();
            command.Questions?.ForEach(questionId =>
                questions.Add(
                    _questionService.GetQuestion(new GetQuestionQuery(questionId))
                )
            );

            var quiz = new Quiz(
                Guid.NewGuid(),
                command.OwnerId,
                questions,
                command.Name
            );

            _quizRepository.Add(quiz);

            _unitOfWork.Commit();
        }

        public void AddQuestionToQuiz(AddQuestionToQuizCommand command)
        {
            var quiz = _quizRepository.GetById(command.QuizId);

            quiz.AddQuestion(_questionService.GetQuestion(new GetQuestionQuery(command.QuestionId)));

            _quizRepository.Update(quiz);
            _unitOfWork.Commit();
        }

        public List<Quiz> GetUserQuizzes(ListOwnedQuizQuery query)
        {
            return _quizRepository.GetAll().Where(q => q.OwnerId == query.OwnerId).ToList();
        }

        public Guid CreateQuizGame(CreateQuizGameCommand command)
        {
            var id = _quizGameService.CreateQuizGame(command);
            _unitOfWork.Commit();
            return id;
        }

        public void AddPointsToParticipant(AddPointsToParticipantCommand command)
        {
            _quizGameService.AddPointsToParticipant(command);
            _unitOfWork.Commit();
        }

        public void GoToNextQuestion(GoToNextQuestionCommand command)
        {
            _quizGameService.GoToNextQuestion(command);
            _unitOfWork.Commit();
        }

        public void ChangeQuizGameState(ChangeQuizGameStateCommand command)
        {
            _quizGameService.ChangeQuizGameState(command);
            _unitOfWork.Commit();
        }

        public void JoinQuizGame(JoinQuizGameCommand command)
        {
            _quizGameService.JoinQuizGame(command);
            _unitOfWork.Commit();
        }

        public Question? GetCurrentQuizQuestion(CurrentQuestionQuery query)
        {
            var quizGame = _quizGameService.GetQuizGame(query.QuizId);

            if (quizGame == null)
            {
                throw new KeyNotFoundException($"No quiz game found with id {query.QuizId}");
            }

            return quizGame.CurrentQuestion();
        }

        public QuizGameParticipant? GetQuizWinner(QuizWinnerQuery query)
        {
            var quizGame = _quizGameService.GetQuizGame(query.QuizId);

            if (quizGame == null)
            {
                throw new KeyNotFoundException($"No quiz game found with id {query.QuizId}");
            }

            return quizGame.Winner;
        }

        public List<QuizGameParticipant> GetQuizParticipants(ListQuizGameParticipants query)
        {
            return _quizGameService.GetQuizGameParticipants(query);
        }

        public List<Question> GetQuestions()
        {
            return _questionService.GetQuestions(new ListQuestionsQuery());
        }
    }
}