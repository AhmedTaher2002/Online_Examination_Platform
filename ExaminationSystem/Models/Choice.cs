using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class Choice : BaseModel
    {

       
        [Required]
        public string Text { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public StudentAnswer StudentAnswer { get; set; } = null!;
    }
} 