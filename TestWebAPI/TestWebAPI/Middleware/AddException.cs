using System.Globalization;

namespace TestWebAPI.Middleware
{
    public class AddException: Exception
    {
        public AddException() : base() { }
        public AddException(string message) : base(message) { }        
        public AddException(string message, params object[] args)
            :base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
