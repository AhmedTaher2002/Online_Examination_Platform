
using ExaminationSystem.Data;
using System.Linq.Expressions;

namespace ExaminationSystem.Filters
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly Context _context;
        public TransactionMiddleware(Context context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var transaction=_context.Database.BeginTransaction();
            try
            {
                await next(context);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch (Exception ex) {
                await transaction.RollbackAsync();
            }
            throw new NotImplementedException();
        }
    }
}
