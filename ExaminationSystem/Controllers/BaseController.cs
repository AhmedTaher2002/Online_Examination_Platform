using AutoMapper;
using ExaminationSystem.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        protected BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected ResponseViewModel<TViewModel> HandleResult<TEntity, TViewModel>(ResponseViewModel<TEntity> result)
        {
            if (!result.IsSuccess)
            {
                return new FailResponseViewModel<TViewModel>(
                    result.Massage,
                    result.IsError
                );
            }

            var data = _mapper.Map<TViewModel>(result.Data);
            return new SuccessResponseViewModel<TViewModel>(data);
        }
    }
}
