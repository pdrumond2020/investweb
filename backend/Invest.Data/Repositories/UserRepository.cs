using Invest.Data.Context;
using Invest.Data.Repositories.Base;
using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Template.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InvestContext context)
            : base(context) { }

        public User GetByDocumentAndPassword(string document, string password)
        {
            return Find(x => x.Document.ToLower() == document.ToLower() && x.Password == password && x.IsActive);
        }

        public User GetByDocument(string document)
        {
            return Find(x => x.Document.ToLower() == document.ToLower() && x.IsActive);
        }

        public User GetByDocumentAndCode(string document, string code)
        {
            return Find(x => x.Document.ToLower() == document.ToLower() && x.Code.ToUpper() == code.ToUpper() && x.IsActive);
        }

        public IQueryable<User> GetByProfileId(int profileId)
        {
            return Query(x => x.IsActive);
        }

        public User GetById(int userId)
        {
            return Find(x => x.Id == userId);
        }

        public IQueryable<User> Get()
        {
            return Query(x => x.IsActive);
        }

        public IQueryable<User> GetAll()
        {
            return Query();
        }
    }
}