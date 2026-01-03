using AutoMapper;
using ExaminationSystem.ViewModels.Choice;

namespace ExaminationSystem.DTOs.Choice
{
    public class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {           //sourse -> destination
            //Service
            CreateMap<Models.Choice, GetAllChoicesDTO>();
            CreateMap<Models.Choice, GetChoiceByIdDTO>();

            CreateMap<CreateChoiceDTO, Models.Choice>();
            CreateMap<UpdateChoiceDTO, Models.Choice>();


            //Controller
            CreateMap<GetAllChoicesDTO, GetAllChoicesViewModel>();
            CreateMap<GetChoiceByIdDTO, GetChoiceByIdViewModel>();

            CreateMap<CreateChoiceViewModel, CreateChoiceDTO>();
            CreateMap<UpdateChoiceViewModel, UpdateChoiceDTO>();

        }
    }
}