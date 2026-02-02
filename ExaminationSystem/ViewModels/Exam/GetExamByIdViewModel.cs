namespace ExaminationSystem.ViewModels.Exam
{
    public class GetExamByIdViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }=null!;
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
    }
}
