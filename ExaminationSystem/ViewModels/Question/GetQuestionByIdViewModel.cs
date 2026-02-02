namespace ExaminationSystem.ViewModels.Question
{
    public class GetQuestionByIdViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }= null!;
        public Models.Enums.QuestionLevel Level { get; set; }
    }
}
