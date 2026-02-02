namespace ExaminationSystem.DTOs.Exam
{
    public class GetExamByIdDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }= null!;
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
    }
}
