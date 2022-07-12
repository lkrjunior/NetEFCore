using System;
using Microsoft.AspNetCore.Http;

namespace NetEFCore.Core.Models.Response
{
    public sealed class ServiceResponse<TResponse>
        where TResponse : class
    {
        public int HttpStatusCode { get; private set; }
        public TResponse? Data { get; private set; }
        public string? ErrorTitle { get; private set; }
        public string? ErrorMessage { get; private set; }
        public bool HasError { get; private set; }

        private static ServiceResponse<TResponse> AsError(int httpStatusCode, string errorTitle, string errorMessage)
        {
            return new ServiceResponse<TResponse>()
            {
                HttpStatusCode = httpStatusCode,
                HasError = true,
                ErrorTitle = errorTitle,
                ErrorMessage = errorMessage
            };
        }

        public static ServiceResponse<TResponse> AsOk(TResponse? responseData)
        {
            return new ServiceResponse<TResponse>()
            {
                HttpStatusCode = StatusCodes.Status200OK,
                HasError = false,
                Data = responseData
            };
        }

        public static ServiceResponse<TResponse> AsNotFound(string errorMessage)
        {
            var statusCode = StatusCodes.Status404NotFound;

            return AsError(statusCode, "Not Found", errorMessage);
        }
    }
}

