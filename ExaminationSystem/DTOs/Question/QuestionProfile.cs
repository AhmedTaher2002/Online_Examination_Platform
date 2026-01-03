using AutoMapper;
using ExaminationSystem.ViewModels.Question;

namespace ExaminationSystem.DTOs.Question
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            //Service
            CreateMap<Models.Question, GetAllQuestionsDTO>();
            CreateMap<Models.Question, GetQuestionByIdDTO>();

            CreateMap<CreateQuestionDTO, Models.Question>();
            CreateMap<UpdateQuestionDTO, Models.Question>();

            //Controller
            CreateMap<GetAllQuestionsDTO, GetAllQuestionsViewModel>();
            CreateMap<GetQuestionByIdDTO, GetQuestionByIdViewModel>();
            
            CreateMap<CreateQuestionViewModel, CreateQuestionDTO>();
            CreateMap<UpdateQuestionViewModel, UpdateQuestionDTO>();
        }
    }
}
