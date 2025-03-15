using ProjectManager.Database.Entities;

namespace ProjectManager.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddNewUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
    }
}
