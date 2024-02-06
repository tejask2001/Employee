namespace FirstAPI.Exceptions
{
    public class InvalidUserException:Exception
    {
        string message;
        public InvalidUserException()
        {
            message = "Invalid username or password";
        }

        public override string Message => message;
    }
}
