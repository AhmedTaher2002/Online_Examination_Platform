namespace ExaminationSystem.ViewModels.Choice
{
    public class GetAllChoicesViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
