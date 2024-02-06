namespace FirstAPI.Exceptions
{
    public class NoRequestRaisedException:Exception
    {
        private readonly string _message;

        public NoRequestRaisedException()
        {
            _message = "No Request Raised with given Id";
        }

        public override string Message => _message;
    }
}
