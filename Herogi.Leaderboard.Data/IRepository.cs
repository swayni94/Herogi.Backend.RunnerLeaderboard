using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Herogi.Leaderboard.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>> query);
        void AddEntity(T entity);
    }
}
