namespace ExaminationSystem.ViewModels.Choice
{
    public class GetChoiceByIdViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; } = null!;
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
