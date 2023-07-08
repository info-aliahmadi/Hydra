using System.ComponentModel;

namespace Hydra.Kernel.Models
{
    /// <summary>
    /// for simple use we add default generic type
    /// </summary>
    public class Result : Result<string> { }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The data result you want return</typeparam>
    public class Result<T>
    {
        public Result()
        {
            Status = ResultStatusEnum.Succeeded;
            Errors = new List<Error>();
        }

        public bool Succeeded => Status == ResultStatusEnum.Succeeded;

        public ResultStatusEnum Status { get; set; }

        public string StatusDescription => Status.Description();

        public string Message { get; set; }

        public List<Error> Errors { get; set; }

        public T Data { get; set; }
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
    public class Error
    {
        public Error()
        {

        }
        public Error(string property, string description)
        {
            this.Property = property;
            this.Description = description;
        }
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Property { get; set; } 

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; } 
    }
}
