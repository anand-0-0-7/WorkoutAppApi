using System.Threading.Tasks;
using MyWorkoutAppApi.Models;

namespace MyWorkoutAppApi.Data
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string username);
        Task AddUserAsync(User user);
        Task<User> ValidateUserAsync(string username, string password);
    }
}
