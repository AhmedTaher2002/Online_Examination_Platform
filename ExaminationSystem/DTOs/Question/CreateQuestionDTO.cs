namespace ExaminationSystem.DTOs.Question
{
    public class CreateQuestionDTO
    {
        public string Text { get; set; }
        public Models.Enums.QuestionLevel Level { get; set; }
        public int InstructorId { get; set; }
    }
}
