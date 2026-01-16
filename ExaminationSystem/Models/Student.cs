namespace ExaminationSystem.Models
{
    public class Student : User
    {
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<StudentExam> StudentExams { get; set; } = new HashSet<StudentExam>();
    }
} 