using ExaminationSystem.DTOs.Choice;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.DTOs.Other
{
    public class GetStudentAnswersDTO
    {
        public string Text { get; set; } 
        public QuestionLevel Level { get; set; }
        public int SelectedChoiceId { get; set; }
        public IEnumerable<GetChoiceByIdDTO> GetChoiceByIdDTO { get; set; }
    }
}
