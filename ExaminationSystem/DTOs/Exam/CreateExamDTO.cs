namespace ExaminationSystem.DTOs.Exam
{
    public class CreateExamDTO
    {
        public string Title { get; set; }
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
