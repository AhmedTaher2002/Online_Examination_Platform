using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class StudentAnswer : BaseModel
    {
        
        public StudentExam StudentExam { get; set; } = null!;
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public int SelectedChoiceId { get; set; }
        public Choice SelectedChoice { get; set; } = null!;
        public bool IsCorrect { get; internal set; }
    }
} 