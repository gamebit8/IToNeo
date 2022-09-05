using System.Threading.Tasks;

namespace IToNeo.WebAPI.Interfaces
{
    public interface ICacheService<T> where T : class
    {
        public Task<T> GetAsync(string key);
        public Task SetAsync(string key, T value);
        public Task SetAsync(string key, T value, int expirationRelativeInMinutes);
    }
}
