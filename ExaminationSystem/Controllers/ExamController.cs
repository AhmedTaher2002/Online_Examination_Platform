using AutoMapper;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.DTOs.Other;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Other;
using ExaminationSystem.ViewModels.Question;
using ExaminationSystem.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly ExamService _examService;
        private readonly IMapper _mapper;

        public ExamController( IMapper mapper)
        {
            _examService = new ExamService(mapper);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<GetAllExamsViewModel>>> GetAll()
        {
            var result = await _examService.GetAll();
            return _mapper.Map<ResponseViewModel<IEnumerable<GetAllExamsViewModel>>>(result);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<GetExamByIdViewModel>> GetByID(int id)
        {
            var result = await _examService.GetByID(id);
            return _mapper.Map<ResponseViewModel<GetExamByIdViewModel>>(result);
        }

        [HttpGet("filter")]
        public async Task<ResponseViewModel<IEnumerable<GetAllExamsViewModel>>> Get(int? id, string? title, int? type)
        {
            var result = await _examService.Get(id, title, (Models.Enums.ExamType?)type);
            return _mapper.Map<ResponseViewModel<IEnumerable<GetAllExamsViewModel>>>(result);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Create([FromBody] CreateExamViewModel vm)
        {
            var result = await _examService.Create(_mapper.Map<CreateExamDTO>(vm));
            return _mapper.Map<ResponseViewModel<bool>>(result);
        }

        [HttpPut("{id}")]
        public async Task<ResponseViewModel<bool>> Update(int id, [FromBody] UpdateExamViewModel vm)
        {
            var result = await _examService.Update(id, _mapper.Map<UpdateExamDTO>(vm));
            return _mapper.Map<ResponseViewModel<bool>>(result);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<bool>> SoftDelete(int id)
        {
            var result = await _examService.SoftDelete(id);
            return _mapper.Map<ResponseViewModel<bool>>(result);
        }

        [HttpGet("{examId}/questions")]
        public async Task<ResponseViewModel<IEnumerable<GetAllQuestionsViewModel>>> GetExamQuestions(int examId)
        {
            var result = _examService.GetExamQuestions(examId);
            return _mapper.Map<ResponseViewModel<IEnumerable<GetAllQuestionsViewModel>>>(result);
        }

        [HttpPost("assign-question")]
        public async Task<ResponseViewModel<bool>> AssignQuestion([FromBody] ExamQuestionViewModel vm)
        {
            var result = await _examService.AssignQuestion(_mapper.Map<ExamQuestionDTO>(vm));
            return _mapper.Map<ResponseViewModel<bool>>(result);
        }

        [HttpPost("{examId}/evaluate")]
        public async Task<ResponseViewModel<bool>> EvaluateAllExams(int examId)
        {
            var result = await _examService.EvaluateAllExams(examId);
            return _mapper.Map<ResponseViewModel<bool>>(result);
        }
    }
}
