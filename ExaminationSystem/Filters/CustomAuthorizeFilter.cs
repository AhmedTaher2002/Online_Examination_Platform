using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ExaminationSystem.Filters
{
    public class CustomAuthorizeFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var roleID = context.HttpContext.User.FindFirst(ClaimTypes.Role);
            if (roleID != null &&string.IsNullOrEmpty(roleID.Value)) {
                context.HttpContext.Response.StatusCode = 403; // Forbidden
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Access Denied" });
                return;
            }

            }
        }
}
