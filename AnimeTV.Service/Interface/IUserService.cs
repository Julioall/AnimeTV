using AnimeTV.Domain.Models.User;

namespace AnimeTV.Service.Interface
{
    public interface IUserService
    {
        public Task AddAsync(User user);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(User user);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<User> GetByUsernameAsync(string username);
        public Task<IEnumerable<User>> GetByRoleAsync(string role);

    }
}
