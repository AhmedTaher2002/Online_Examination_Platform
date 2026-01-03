namespace ExaminationSystem.DTOs.Exam
{
    public class GetAllExamsDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
    }
}
