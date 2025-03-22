using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ServiceUser.WebApi.Models.Responses;
using ServiceUser.Domain.Exceptions;
namespace ServiceUser.WebApi.Filters
{
    public class CentralizedExceptionHandlingFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var (message, statusCode) = TryGetUserMessageFromException(context);

            if (message != null && statusCode != 0)
            {
                context.Result = new ObjectResult(new ErrorResponse(message, statusCode))
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
            }
        }

        private (string?, int) TryGetUserMessageFromException(ExceptionContext context)
        {
            return context.Exception switch
            {
                UserProfileNotFoundException => ("Пользователь с данным профилем не найден", StatusCodes.Status400BadRequest),
                UserProfileWithAccountAlreadyExistsException => ("У данного аккаунта профиль уже существует", StatusCodes.Status400BadRequest),
                Exception => ("Внутренняя ошибка сервера", StatusCodes.Status500InternalServerError),
                _ => (null, 0)
            };
        }
    }
}