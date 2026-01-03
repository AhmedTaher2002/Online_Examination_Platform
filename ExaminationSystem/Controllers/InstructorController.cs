using AutoMapper;
using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.DTOs.Other;
using ExaminationSystem.DTOs.Question;
using ExaminationSystem.DTOs.Student;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Instructor;
using ExaminationSystem.ViewModels.Other;
using ExaminationSystem.ViewModels.Question;
using ExaminationSystem.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

[Route("[controller]/[action]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly InstructorService _instructorService;
    private readonly IMapper _mapper;
    public InstructorController(IMapper mapper)
    {
        _instructorService = new InstructorService(mapper);
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<GetAllInstructorsViewModel> GetAll()
    {
        return _mapper.Map<IEnumerable<GetAllInstructorsViewModel>>(_instructorService.GetAll());
        /*
        return _instructorService.GetAll()
            .Select(i => new GetAllInstructorsViewModel
            {
                ID = i.ID,
                Name = i.Name,
                Email = i.Email
            });
        */
    }

    [HttpGet]
    public IEnumerable<GetAllInstructorsViewModel> Get(int? id, string? name, string? email)
    {
        return _mapper.Map<IEnumerable<GetAllInstructorsViewModel>>( _instructorService.Get(id, name, email));
    }
    [HttpGet]
    public async Task<GetInstructorByIdViewModel> GetByID(int id)
    {
        return _mapper.Map<GetInstructorByIdViewModel>(_instructorService.GetByID(id));    
        /*
        var dto = await _instructorService.GetByID(id);
        return new GetInstructorByIdViewModel
        {
            ID = dto.ID,
            Name = dto.Name,
            Email = dto.Email
        };
        */
    }

    [HttpPost]
    public async Task<bool> Create(CreateInstructorViewModel vm)
    {
        var res = _mapper.Map<CreateInstructorDTO>(vm);
         await _instructorService.Create(res);
        /*
        _instructorService.Create(new CreateInstructorDTO
        {
            Name = vm.Name,
            Email = vm.Email
        });
        */
        return true;
    }

    [HttpPut("{id}")]
    public async Task<bool> Update(int id, UpdateInstructorViewModel vm)
    {
        await _instructorService.Update(id,_mapper.Map<UpdateInstructorDTO>(vm));
        /*
        _instructorService.Update(id, new UpdateInstructorDTO
        {
            Name = vm.Name,
            Email = vm.Email
        });
        */
        return true;
    }

    [HttpDelete("{id}")]
    public async Task<bool> SoftDelete(int id)
    {
        await _instructorService.SoftDelete(id);
        return true;
    }

    [HttpPost]
    public async Task AddQuestionToExam(int examId, int questionId)
    {
        await _instructorService.AddQuestionToExam(examId, questionId);
    }
    [HttpPost]
    public async Task RemoveQuestionFromExam(int examId, int questionId)
    {
        await _instructorService.RemoveQuestionFromExam(examId, questionId);
    }
    [HttpGet]
    public IEnumerable<GetAllQuestionsViewModel> GetQuestionsByExam(int examId) 
    {
        return _mapper.Map<IEnumerable<GetAllQuestionsViewModel>>(_instructorService.GetQuestionsByExam(examId));
    }
    [HttpGet]
    public IEnumerable<GetAllStudentsViewModel> GetStudentsInCourse(int courseId) 
    { 
        return _mapper.Map<IEnumerable<GetAllStudentsViewModel>>(_instructorService.GetStudentsInCourse(courseId));
    }
    [HttpPost]
    public async Task<bool> AssignStudentToCourse(StudentCourseDTO studentCourseDTO)
    {
        await _instructorService.AssignStudentToCourse(studentCourseDTO);
        return true;
    }

    [HttpGet]
    public IEnumerable<GetStudentAnswersViewModel> GetStudentAnswers(int studentId, int examId)
    {
        return _mapper.Map<IEnumerable<GetStudentAnswersViewModel>>(_instructorService.GetStudentAnswers(studentId, examId));
    }


}
