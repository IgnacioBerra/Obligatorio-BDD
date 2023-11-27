using API.Clases;
using API.Data;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;
using API.Controllers;
public class RedisCacheService : IRedisCache
    {
        private readonly IDistributedCache _cache;
        private int logIdNumer = 0;
        public RedisCacheService(IDistributedCache cache, string connectionString)
        {
            _cache = cache;
            var optionsBuilder = new DbContextOptionsBuilder<DataInfo>();
            optionsBuilder.UseSqlServer(connectionString);
            DataInfo context = new DataInfo(optionsBuilder.Options);
            List<Logins> listaLog = context.logins.FromSqlRaw("Select * from dbo.logins").ToList();
            loadUsers(listaLog);
        }

        private void loadUsers(List<Logins> listaUsers)
        {
            foreach(Logins user in listaUsers)
            {
                this.logIdNumer = user.LogId;
                AddRegistration(user.Password);
            }
        }

        public bool AddRegistration(string value)
        {
            var dataToCache = Encoding.UTF8.GetBytes(value);
            _cache.Set(this.logIdNumer.ToString(), dataToCache);
            this.logIdNumer++;
            return true;
        }

        public byte[] GetUserRegistrationState(string key)
        {
            return _cache.Get(key);
        }

        public void deleteRegister(int logId)
        {
            _cache.Remove(logId.ToString());
        }
    
        public void ChangePassword(int logId, string newPassword)
        {
            var dataToCache = Encoding.UTF8.GetBytes(newPassword);
            _cache.Set(logId.ToString(), dataToCache);
        }
    }