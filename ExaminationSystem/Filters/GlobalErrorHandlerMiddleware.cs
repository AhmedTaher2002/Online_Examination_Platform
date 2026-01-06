using System.Data;

namespace ExaminationSystem.Filters
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {

                await next(context);

            }
            catch (Exception ex) {


            }
        }
    }
}
