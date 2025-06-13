using System.Security.Claims;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Api.Middleware
{
    public class CurrentUserMiddleware : IMiddleware
    {
        private readonly IUserRepository _userRepository;

        public CurrentUserMiddleware(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            if (ctx.User.Identity?.IsAuthenticated == true)
            {
                var idClaim = ctx.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Console.WriteLine(idClaim);
                if (Guid.TryParse(idClaim, out var id))
                {
                    var user = _userRepository.GetById(id);
                    ctx.Items["CurrentUser"] = user;
                }
            }
            await next(ctx);
        }
        
    }
}