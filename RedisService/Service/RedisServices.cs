using RedisService.IService;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService.Service
{
    public class RedisServices : IRedisService
    {
        private readonly IDatabase _db;
        public RedisServices(IConnectionMultiplexer conn)
        {
            _db = conn.GetDatabase();   
        }
        public async Task<string?> GetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }


        public async Task SetAsync(string key, string value, TimeSpan expiry)
        {
            await _db.StringSetAsync(key, value, expiry);
        }

    }
}
