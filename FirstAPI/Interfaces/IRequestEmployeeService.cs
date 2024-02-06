using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IRequestEmployeeService
    {
        public Task<Request> CreateRequest(Request request);
        public Task<Request> DeleteRequest(int id);
        public  Task<IList<Request>> GetAllRequestByEmployee(int employeeId);
        public Task<Request> GetRequestStatus(int id);

    }
}
