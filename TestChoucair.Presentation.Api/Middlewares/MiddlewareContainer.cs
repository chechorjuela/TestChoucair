namespace TestChoucair.Presentation.Middleware
{
    public class MiddlewareContainer
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareContainer> _logger;
        private readonly RequestDelegate _innerMiddlewarePipeline;

        public MiddlewareContainer(RequestDelegate next, ILogger<MiddlewareContainer> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;

            // Configurar el pipeline interno de middlewares
            var innerBuilder = new ApplicationBuilder(serviceProvider);

            // Añadir los middlewares internos
            innerBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
            innerBuilder.UseMiddleware<RequestLoggingMiddleware>();

            innerBuilder.Run(_next);
            _innerMiddlewarePipeline = innerBuilder.Build();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _innerMiddlewarePipeline(context);
        }
    }
}
