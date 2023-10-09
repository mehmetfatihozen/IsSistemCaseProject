using System.Text.Json.Serialization;

namespace IsSistemCase.Core.DTOs.ResponseDTOs
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public List<string> ErrorMessages { get; set; }

        #region Success

        public static BaseResponse<T> Success()
        {
            return new BaseResponse<T> { HasError = false };
        }
        public static Task<BaseResponse<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T> { Data = data, HasError = false };
        }
        public static Task<BaseResponse<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        #endregion

        #region Fail

        public static BaseResponse<T> Fail()
        {
            return new BaseResponse<T> { HasError = true };
        }
        public static Task<BaseResponse<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static BaseResponse<T> Fail(string message)
        {
            return new BaseResponse<T> { HasError = true, ErrorMessages = new List<string> { message } };
        }
        public static Task<BaseResponse<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static BaseResponse<T> Fail(List<string> messages)
        {
            return new BaseResponse<T> { HasError = true, ErrorMessages = messages };
        }
        public static Task<BaseResponse<T>> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        #endregion
    }
}
