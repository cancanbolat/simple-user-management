namespace UserManagement.Shared.SharedDTOs
{
    public class BaseResponse<T>
    {
        //public Token Token { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto Error { get; set; }
        public string Message { get; set; }
        //[JsonIgnore]
        public bool IsSuccess { get; set; }


        public static BaseResponse<T> Success(T data, int statusCode)
        {
            return new BaseResponse<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
        }

        public static BaseResponse<T> Success(T data, string message, int statusCode)
        {
            return new BaseResponse<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccess = true };
        }

        public static BaseResponse<T> Success(int statusCode)
        {
            return new BaseResponse<T> { Data = default, StatusCode = statusCode, IsSuccess = true };
        }

        public static BaseResponse<T> Fail(string message, int statuscode, bool isSuccess)
        {
            return new BaseResponse<T> { Message = message, StatusCode = statuscode, IsSuccess = isSuccess };
        }

        public static BaseResponse<T> Fail(int statusCode)
        {
            return new BaseResponse<T> { StatusCode = statusCode, IsSuccess = false };
        }

        public static BaseResponse<T> Fail()
        {
            return new BaseResponse<T> { IsSuccess = false };
        }

        public static BaseResponse<T> Fail(string errorMessage, int statusCode)
        {
            var errorDto = new ErrorDto(errorMessage);
            return new BaseResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccess = false };
        }
    }
}
