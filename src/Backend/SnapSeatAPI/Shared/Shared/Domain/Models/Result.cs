namespace Shared.Domain.Models
{
    using System.Net;

    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string? Error { get; }
        public HttpStatusCode StatusCode { get; }

        private Result(T value, HttpStatusCode statusCode)
        {
            IsSuccess = true;
            Value = value;
            StatusCode = statusCode;
        }

        private Result(string error, HttpStatusCode statusCode)
        {
            IsSuccess = false;
            Error = error;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T value) =>
            new(value, HttpStatusCode.OK);

        public static Result<T> Failure(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new(error, statusCode);
    }


}
