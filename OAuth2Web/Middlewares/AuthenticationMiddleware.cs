namespace OAuth2Web.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        // JWT Secret must have 32 chars
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachAccountToContext(context, dataContext, token);

            await _next(context);
        }
    }
}