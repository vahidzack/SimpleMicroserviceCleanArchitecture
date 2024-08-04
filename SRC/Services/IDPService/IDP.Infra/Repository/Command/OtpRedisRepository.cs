using IDP.Domain.DTO;
using IDP.Domain.IRepository.Command;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IDP.Infra.Repository.Command
{
    public class OtpRedisRepository : IOtpRedisRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public OtpRedisRepository(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _configuration = configuration;
        }

        public async Task<bool> AddAsync(Otp entity)
        {
            int time = Convert.ToInt32(_configuration.GetSection("Opt:OptTime").Value);
            _distributedCache.SetString(entity.UserId.ToString(), JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(time)));
            return true;
        }

        public async Task<bool> DeleteAsync(Otp entity)
        {
            _distributedCache.RemoveAsync(entity.UserId.ToString());
            return true;
        }

        public Task<bool> UpdateAsync(Otp entity)
        {
            throw new NotImplementedException();
        }
    }
}
