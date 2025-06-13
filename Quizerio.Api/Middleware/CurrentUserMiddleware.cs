using System.Security.Claims;
using Quizerio.Application.User;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Api.Middleware
{
    public class CurrentUserMiddleware : IMiddleware
    {
        private readonly IUserFacade _userFacade;

        public CurrentUserMiddleware(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            if (ctx.User.Identity?.IsAuthenticated == true)
            {
                var idClaim = ctx.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Console.WriteLine(idClaim);
                if (Guid.TryParse(idClaim, out var id))
                {
                    var user = _userFacade.GetUser(new GetUserQuery(id));
                    ctx.Items["CurrentUser"] = user;
                }
            }
            await next(ctx);
        }
        
    }
}