namespace FirstAPI.Exceptions
{
    public class NoSuchDepartmentException:Exception
    {
        private readonly string _message;

        public NoSuchDepartmentException()
        {
            _message = "No department found with given Id";
        }

        public override string Message => _message;
    }
}
