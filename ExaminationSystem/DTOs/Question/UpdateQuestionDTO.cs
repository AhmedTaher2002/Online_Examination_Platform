namespace ExaminationSystem.DTOs.Question
{
    public class UpdateQuestionDTO
    {
        public string Text { get; set; }
        public Models.Enums.QuestionLevel Level { get; set; }
    }
}
