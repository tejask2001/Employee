using FirstAPI.Context;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FirstAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;
        private readonly ILogger<RequestRepository> _logger;
        public RequestRepository(RequestTrackerContext context, ILogger<RequestRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Request> Add(Request item)
        {
            item.RaisedDate = DateTime.Now;
            _context.Requests.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await GetAsync(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Request deleted " + request.Id);
                return request;
            }
            return null;
        }

        public async Task<Request> GetAsync(int key)
        {
            var request = _context.Requests.FirstOrDefault(r => r.Id == key);
            if (request != null)
                return request;
            return null;
        }

        public async Task<List<Request>> GetAsync()
        {
            return _context.Requests.ToList();
        }

        public async Task<Request> Update(Request item)
        {
            var request = await GetAsync(item.Id);
            if (request != null)
            {
                _context.Entry<Request>(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
