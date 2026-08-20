using Forge.WebApi.Shared.ExceptionBase;
using Forge.WebApi.Shared.Responses;

namespace Forge.WebApi.Api.Exceptions
{
    public static class ExceptionFilterMiddleware
    {
        public static void UseExceptionFilter(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (ForgeWebApiException ex)
                {
                    context.Response.ContentType = "application/json";

                    if (ex is ErrorOnValidationException validationEx)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new ResponseErrorJson(validationEx.ErrorMessages));
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new ResponseErrorJson("Erro do projeto"));
                    }
                }
                catch (Exception)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsJsonAsync(new ResponseErrorJson("Erro desconhecido"));
                }
            });
        }
    }

}
