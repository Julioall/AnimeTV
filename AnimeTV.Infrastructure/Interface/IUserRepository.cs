using AnimeTV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTV.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetByRoleAsync(string role);
    }
}
