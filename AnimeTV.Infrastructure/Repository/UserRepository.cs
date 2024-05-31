using AnimeTV.Domain.Models.User;
using AnimeTV.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTV.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
