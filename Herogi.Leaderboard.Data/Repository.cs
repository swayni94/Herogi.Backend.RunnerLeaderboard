using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Herogi.Leaderboard.Data.Entity;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Herogi.Leaderboard.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 
    {
        private IMongoCollection<T> collection;
        private ILogger<Repository<T>> _logger;

        public Repository(string connectionString, string dataBaseName, ILogger<Repository<T>> logger)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dataBaseName);
            collection = database.GetCollection<T>(typeof(T).Name);
            _logger = logger;
        }

        public void AddEntity(T entity)
        {
            var term = collection.Find(x => x.Id == entity.Id).FirstOrDefault();
            try
            {
                if(term==null)
                    collection.InsertOne(entity);   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> query)
        {
            try
            {
                return collection.Find(query).ToList();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
