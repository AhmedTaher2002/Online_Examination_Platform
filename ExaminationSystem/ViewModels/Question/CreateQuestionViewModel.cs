namespace ExaminationSystem.ViewModels.Question
{
    public class CreateQuestionViewModel
    {
        public string Text { get; set; }
        public Models.Enums.QuestionLevel Level { get; set; }
        public int InstructorId { get; set; }
    }
}
