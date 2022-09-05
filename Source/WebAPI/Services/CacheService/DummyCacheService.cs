using IToNeo.WebAPI.Interfaces;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.Services.CacheService
{
    public class DummyCacheService<T> : ICacheService<T> where T : class
    {
        public DummyCacheService()
        {

        }

        public async Task<T> GetAsync(string key)
        {
            return await Task.Run(() => EmptyMetodT());
        }

        public async Task SetAsync(string key, T value)
        {
            await Task.Run(() => EmptyMetod());
        }

        public async Task SetAsync(string key, T value, int expirationRelativeInMinutes)
        {
            await Task.Run(() => EmptyMetod());
        }

        private void EmptyMetod()
        {

        }

        private T EmptyMetodT()
        {
            return default;
        }
    }
}
