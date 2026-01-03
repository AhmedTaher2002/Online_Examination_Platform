using AutoMapper;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Exam;

namespace ExaminationSystem.DTOs.Exam
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {               //sourse -> destination
            //Service
            CreateMap<Models.Exam, GetAllExamsDTO>();
            CreateMap<Models.Exam, GetExamByIdDTO>();

            CreateMap<CreateExamDTO, Models.Exam>();
            CreateMap<UpdateExamDTO, Models.Exam>();

            //Controller
            CreateMap<GetAllExamsDTO, GetAllExamsViewModel>();
            CreateMap<GetExamByIdDTO, GetExamByIdViewModel>();

            CreateMap<CreateExamViewModel, CreateExamDTO>();
            CreateMap<UpdateExamViewModel, UpdateExamDTO>();


        }
    }
}
