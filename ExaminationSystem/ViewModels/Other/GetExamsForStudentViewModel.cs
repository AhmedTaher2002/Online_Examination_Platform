using ExaminationSystem.DTOs.Exam;

namespace ExaminationSystem.ViewModels.Other
{
    public class GetExamsForStudentViewModel
    {
        public string studentName { get; set; }=null!;
        public string StudentId { get; set; }= null!;

        public IEnumerable<GetAllExamsDTO> getAllExamsDTO { get; set; }=new HashSet<GetAllExamsDTO>();

    }
}
