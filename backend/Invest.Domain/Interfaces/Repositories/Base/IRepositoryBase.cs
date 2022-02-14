using System;

namespace Invest.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity model);

        bool Update(TEntity model);

        bool Delete(TEntity model);
    }
}