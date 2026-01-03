namespace ExaminationSystem.ViewModels.Exam
{
    public class CreateExamViewModel
    {
        public string Title { get; set; }
        public Models.Enums.ExamType Type { get; set; }
        public int CourseId { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
