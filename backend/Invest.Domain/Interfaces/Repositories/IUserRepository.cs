using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Repositories.Base;
using System.Linq;

namespace Invest.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByDocumentAndPassword(string document, string password);

        User GetByDocument(string document);

        User GetByDocumentAndCode(string document, string code);

        IQueryable<User> GetByProfileId(int profileId);

        User GetById(int userId);

        IQueryable<User> Get();

        IQueryable<User> GetAll();
    }
}