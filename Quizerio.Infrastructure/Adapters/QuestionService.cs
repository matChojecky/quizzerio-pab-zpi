using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            List<Answer> answers =
                command.Answers.Select(a => new Answer(Guid.NewGuid(), a.Text, a.IsCorrect)).ToList();
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

            current.QuestionText = command.QuestionText;
            current.Difficulty = command.Difficulty;
            current.Answers = command.Answers.Select(a =>
                new Answer(
                    a.Id ?? throw new ArgumentException("Cannot perform update"),
                    a.Text,
                    a.IsCorrect
                )
            ).ToList();
            
            current.Category = category;

            _questionRepository.Update(current);
            _unitOfWork.Commit();
        }

        public Question GetQuestion(GetQuestionQuery query)
        {
            return _questionRepository.GetById(query.Id);
        }

        public List<Question> GetQuestions(ListQuestionsQuery query)
        {
            var filters = new List<Expression<Func<Question, bool>>>();
            
            if (query.Difficulty is { } difficulty)
            {
                filters.Add(q => q.Difficulty == difficulty);
            }

            if (query.Status is { } status)
            {
                filters.Add(q => q.Status == status);
            }
            
            return _questionRepository.GetAll(filters);
        }
    }
}