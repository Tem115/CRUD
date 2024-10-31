

namespace CRUD.Abstractions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DefaultExceptionAttribute : Attribute
    {
        public string Message { get; }

        public DefaultExceptionAttribute(string message) => Message = message;
    }
}
