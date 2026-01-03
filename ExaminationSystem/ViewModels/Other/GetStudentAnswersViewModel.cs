using ExaminationSystem.DTOs.Choice;
using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.ViewModels.Other
{
    public class GetStudentAnswersViewModel    {
        public string Text { get; set; }
        public QuestionLevel Level { get; set; }
        public int SelectedChoiceId { get; set; }
        public IEnumerable<GetChoiceByIdDTO> GetChoiceByIdDTO { get; set; }

    }
}
