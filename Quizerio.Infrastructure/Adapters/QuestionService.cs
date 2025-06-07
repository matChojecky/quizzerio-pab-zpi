using System;
using System.Collections.Generic;
using System.Linq;
using Quizerio.Application;
using Quizerio.Application.Quiz;
using Quizerio.Application.Quiz.Commands;
using Quizerio.Application.Quiz.Queries;
using Quizerio.Domain.Quiz.Model;
using Quizerio.Domain.Quiz.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(
            IUnitOfWork unitOfWork,
            IQuestionRepository questionRepository,
            IQuestionCategoryRepository questionCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _questionCategoryRepository = questionCategoryRepository;
        }


        public void ChangeQuestionStatus(ChangeQuestionStatusCommand command)
        {
            _questionRepository.UpdateQuestionStatus(command.Id, command.Status);
            _unitOfWork.Commit();
        }

        public void AddQuestion(CreateQuestionCommand command)
        {
            List<Answer> answers = command.Answers.Select(a => new Answer(a.Id ?? Guid.NewGuid(), a.Text, a.IsCorrect))
                .ToList();
            var category = _questionCategoryRepository.GetById(command.CategoryId);

            var question = new Question(
                Guid.NewGuid(),
                command.QuestionText,
                command.Difficulty,
                QuestionStatus.Pending,
                answers,
                category
            );

            _questionRepository.Add(question);
            _unitOfWork.Commit();
        }

        public void DeleteQuestion(DeleteQuestionCommand command)
        {
            _questionRepository.Delete(command.Id);
            _unitOfWork.Commit();
        }

        public void UpdateQuestion(UpdateQuestionCommand command)
        {
            var current = _questionRepository.GetById(command.Id);
            
            var category = _questionCategoryRepository.GetById(command.CategoryId);

            
            var question = new Question(
                current.Id,
                command.QuestionText,
                command.Difficulty,
                QuestionStatus.Pending,
                command.Answers.Select(a => new Answer(a.Id ?? throw new ArgumentException("Cannot perform update"), a.Text, a.IsCorrect)).ToList(),
                category
            );
            
            _questionRepository.Update(question);
            _unitOfWork.Commit();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionRepository.GetById(query.Id);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            return _questionRepository.GetAll();
        }
    }
}