using System.ComponentModel;

namespace Hydra.Kernel.Models
{
    /// <summary>
    /// for simple use we add default generic type
    /// </summary>
    public class  Result : Result<string> { }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The data result you want return</typeparam>
    public class Result<T>
    {
        public Result()
        {
            Status = ResultStatusEnum.Succeeded;
        }

        public bool Succeeded => Status == ResultStatusEnum.Succeeded;

        public ResultStatusEnum Status { get; set; }

        public string StatusDescription => Status.Description();

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public T DataResult { get; set; }
    }

    public enum ResultStatusEnum
    {
        [Description("Succeeded")]
        Succeeded = 0,

        [Description("Failed")]
        Failed = 1,

        [Description("Invalid Validation")]
        InvalidValidation = 2,

        [Description("Not Found")]
        NotFound = 3,

        [Description("Is Not Authorized")]
        IsNotAuthorized = 4,

        [Description("Is Not Allowed")]
        IsNotAllowed = 5,

        [Description("It's Duplicate")]
        ItsDuplicate = 6,

        [Description("Exception Throwed")]
        ExceptionThrowed = 7,

    }
    public static class EnumExtensions
    {
        public static string Description(this ResultStatusEnum val)
        {
            DescriptionAttribute[]? attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;

        }
    }
}
