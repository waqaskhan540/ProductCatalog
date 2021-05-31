using Syndy.Data.Context;
using Syndy.Data.Entities;
using System;
using System.Text;

namespace Syndy.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SyndyDataContext dbContext) : base(dbContext)
        {
        }
    }
}
