namespace ExaminationSystem.DTOs.Choice
{
    public class UpdateChoiceDTO
    {
        public string? Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId{ get; set; }
    }
}
