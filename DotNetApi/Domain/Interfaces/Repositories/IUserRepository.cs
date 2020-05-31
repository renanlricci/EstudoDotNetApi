using DotNetApi.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetApi.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(ObjectId id);
        Task UpdateAsync(User user);
        Task DeleteAsync(ObjectId id);
    }
}
