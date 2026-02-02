namespace ExaminationSystem.DTOs.Exam
{
    public class UpdateExamDTO
    {
        public string Title { get; set; }= null!;   
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
