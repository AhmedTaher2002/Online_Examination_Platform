using ExaminationSystem.DTOs.Exam;

namespace ExaminationSystem.ViewModels.Other
{
    public class GetExamsForStudentViewModel
    {
        string studentName { get; set; }
        public string StudentId { get; set; }

        public IEnumerable<GetAllExamsDTO> getAllExamsDTO { get; set; }

    }
}
