namespace ExaminationSystem.DTOs.Choice
{
    public class CreateChoiceDTO
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }

    }
}
