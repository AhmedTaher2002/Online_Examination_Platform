namespace ExaminationSystem.DTOs.Other
{
    public class StudentAnswerDTO
    {
        public int StudentId { get; set; }
        public int ExamId {  get; set; }
        public int QuestionId { get; set; }
        public int SelectedChoiceId { get; set; }
    }
}
