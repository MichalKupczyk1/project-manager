using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddNewUser(User user, CancellationToken cancellationToken)
        {
            var addedUser = await _context.Users.AddAsync(user, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return addedUser.Entity;
        }

        public async Task<bool> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                var result = await _context.SaveChangesAsync(cancellationToken);

                return result == 1;
            }

            return false;
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            return (await _context.Users.FindAsync(id, cancellationToken))!;
        }

        public async Task<User> UpdateUser(User user, CancellationToken cancellationToken)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return updatedUser.Entity;
        }
    }
}
