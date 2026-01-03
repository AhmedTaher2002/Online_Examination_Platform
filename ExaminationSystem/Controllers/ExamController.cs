using AutoMapper;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
[ApiController]
public class ExamController : ControllerBase
{
    private readonly ExamService _service;
    private readonly IMapper _mapper;
    public ExamController(IMapper mapper)
    {
        _service = new ExamService(mapper);
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<GetAllExamsViewModel> GetAll()
    {
        return _service.GetAll()
            .Select(e => new GetAllExamsViewModel
            {
                ID = e.ID,
                Title = e.Title,
                Type = e.Type,
                CourseId = e.CourseId
            });
    }

    [HttpGet]
    public async Task<GetExamByIdViewModel> GetByID(int id)
    {
        var dto = await _service.GetByID(id);
        return new GetExamByIdViewModel
        {
            ID = dto.ID,
            Title = dto.Title,
            Type = dto.Type,
            CourseId = dto.CourseId
        };
    }

    [HttpPost]
    public bool Create(CreateExamViewModel vm)
    {
        _service.Create(new CreateExamDTO
        {
            Title = vm.Title,
            Type = vm.Type,
            CourseId = vm.CourseId,
            NumberOfQuestions = vm.NumberOfQuestions
        });
        return true;
    }

    [HttpPut]
    public bool Update(int id, UpdateExamViewModel vm)
    {
        _service.Update(id, new UpdateExamDTO
        {
            Title = vm.Title,
            Type = vm.Type,
            NumberOfQuestions = vm.NumberOfQuestions
        });
        return true;
    }

    [HttpDelete]
    public async Task<bool> SoftDelete(int id)
    {
        await _service.SoftDelete(id);
        return true;
    }
}
