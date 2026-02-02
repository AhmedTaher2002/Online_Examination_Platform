using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.DTOs.Question
{
    public class GetAllQuestionsDTO
    {
        public int ID { get; set; }
        public string Text { get; set; }=null!;
        public QuestionLevel Level { get; set; }
    }
}
