using System.Globalization;

namespace TestWebAPI.Middleware
{
    public class GetException : Exception
    {
        public GetException() : base() { }

        public GetException(string message) : base(message) { }
        public GetException(string message, params object[] args)
            :base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
