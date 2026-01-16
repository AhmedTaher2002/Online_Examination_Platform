using ExaminationSystem.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExaminationSystem.Filters
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly Context _context;
        public TransactionMiddleware(Context context) => _context = context;

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            // BeginTransactionAsync preferred and ensure disposal
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await next(httpContext);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }   
}
