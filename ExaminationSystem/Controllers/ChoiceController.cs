using AutoMapper;
using ExaminationSystem.DTOs.Choice;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Choice;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
[ApiController]
public class ChoiceController : ControllerBase
{
    private readonly ChoiceService _service;
    private readonly IMapper _mapper;
    public ChoiceController(IMapper mapper)
    {
        _service = new ChoiceService(mapper);
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<GetAllChoicesViewModel> GetByQuestion(int questionId)
    {
        var choices = _service.GetByQuestionID(questionId);
        return _mapper.Map<IEnumerable<GetAllChoicesViewModel>>(choices);
        /*
        return _service.GetByQuestionID(questionId)
            .Select(c => new GetAllChoicesViewModel
            {
                ID = c.ID,
                Text = c.Text,
                IsCorrect = c.IsCorrect
            });*/
    }

    [HttpPost]
    public async Task<bool> Create(CreateChoiceViewModel vm)
    {
        await _service.Create(new CreateChoiceDTO
        {
            Text = vm.Text,
            IsCorrect = vm.IsCorrect,
            QuestionId = vm.QuestionId
        });
        return true;
    }
}
