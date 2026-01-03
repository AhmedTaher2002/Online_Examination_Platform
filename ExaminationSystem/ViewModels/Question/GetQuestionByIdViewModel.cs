namespace ExaminationSystem.ViewModels.Question
{
    public class GetQuestionByIdViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Models.Enums.QuestionLevel Level { get; set; }
    }
}
