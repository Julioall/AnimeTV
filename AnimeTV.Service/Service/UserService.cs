using AnimeTV.Domain.Models.User;
using AnimeTV.Service.Interface;

namespace AnimeTV.Service.Service
{
    public class UserService : IUserService
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
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

        public Task<User> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }
    }
}
