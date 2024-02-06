namespace FirstAPI.Exceptions
{
    public class NoSuchEmployeeException:Exception
    {
        private string _message;
        public NoSuchEmployeeException()
        {
            _message = "No Employee with given id";
        }

        public override string Message => _message;

    }
}
