using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;

namespace FirstAPI.Services
{
    public class RequestEmployeeService : IRequestEmployeeService
    {
        private readonly IRepository<int, Request> _repository;
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly ILogger<RequestEmployeeService> _logger;

        public RequestEmployeeService(
                        IRepository<int, Request> repository,
                        IRepository<int, Employee> employeeRepository,
                        ILogger<RequestEmployeeService> logger)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        public async Task<Request> CreateRequest(Request request)
        {
            request.Status = "Created";
            var result = await _repository.Add(request);
            return result;
        }

        public async Task<Request> DeleteRequest(int id)
        {
            var request = await _repository.GetAsync(id);
            if (request == null)
            {
                throw new NoSuchRequestException();
            }
            request.Status = "Deleted";
            var result = await _repository.Update(request);
            return result;
        }

        public async Task<IList<Request>> GetAllRequestByEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetAsync(employeeId);
            if (employee == null)
                throw new NoSuchEmployeeException();
            var result = await _repository.GetAsync();
            var requests = result.Where(r => r.Issuer_Id == employeeId);
            if (requests.Count() > 0)
                return requests.ToList();
            throw new NoRequestRaisedException();
        }

        public async Task<Request> GetRequestStatus(int id)
        {
            var result = await _repository.GetAsync(id);
            if (result == null)
                throw new NoRequestRaisedException();
            return result;
        }
    }
}
