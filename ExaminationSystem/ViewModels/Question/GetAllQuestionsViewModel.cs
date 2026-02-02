using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.ViewModels.Question
{
    public class GetAllQuestionsViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }= null!;
        public QuestionLevel Level { get; set; }
    }
}
