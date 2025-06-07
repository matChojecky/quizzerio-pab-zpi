namespace Quizerio.Application.Quiz.Commands
{
    public class AddQuestionCategoryCommand
    {
        public AddQuestionCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
    }
}