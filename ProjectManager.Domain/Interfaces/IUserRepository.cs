using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddNewUser(User user, CancellationToken cancellationToken);
        Task<bool> DeleteUser(int id, CancellationToken cancellationToken);
        Task<User> GetUserById(int id, CancellationToken cancellationToken);
        Task<User> UpdateUser(User user, CancellationToken cancellationToken);
    }
}
