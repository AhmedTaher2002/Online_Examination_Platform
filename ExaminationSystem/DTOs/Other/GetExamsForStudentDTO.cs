using ExaminationSystem.DTOs.Exam;

namespace ExaminationSystem.DTOs.Other
{
    public class GetExamsForStudentDTO
    {
        public string Name {  get; set; }= null!;
        public string StudentId { get; set; } = null!;

        public IEnumerable<GetAllExamsDTO> getAllExamsDTO { get; set; }= new HashSet<GetAllExamsDTO>();
    }
}
