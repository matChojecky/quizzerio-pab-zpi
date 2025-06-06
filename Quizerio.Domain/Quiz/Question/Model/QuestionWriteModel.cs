namespace Quizerio.Domain.Quizz
{
    public record QuestionWriteModel
    {
        public string QuestionText;

        public QuestionDifficulty Difficulty;

        public List<Answer> Answers;
        

        public QuestionWriteModel(string questionText, QuestionDifficulty difficulty, List<Answer> answers)
        {
            QuestionText = questionText;
            Difficulty = difficulty;
            Answers = answers;
        }
    }
}