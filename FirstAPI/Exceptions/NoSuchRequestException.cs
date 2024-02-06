namespace FirstAPI.Exceptions
{
    public class NoSuchRequestException:Exception
    {
        private string _message;
        public NoSuchRequestException()
        {
            _message = "No request found for given id";
        }
        public override string Message => _message;
    }
}
