using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Instructor;

namespace ExaminationSystem.ViewModels.Course
{
    public class GetAllCoursesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Hours { get; set; }
        public GetInstuctorInfoViewModel Instructor { get; set; }=new GetInstuctorInfoViewModel();
    }
}
