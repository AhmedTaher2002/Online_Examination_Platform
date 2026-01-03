namespace ExaminationSystem.DTOs.Question
{
    public class GetQuestionByIdDTO
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Models.Enums.QuestionLevel Level { get; set; }
    }
}
