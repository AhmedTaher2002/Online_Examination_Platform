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

                throw new Exception("An error occurred while processing your request.", ex);
            }
        }
    }
}
