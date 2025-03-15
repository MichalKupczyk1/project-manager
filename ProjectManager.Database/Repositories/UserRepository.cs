using ProjectManager.Database.Entities;
using ProjectManager.Database.Repositories.Interfaces;

namespace ProjectManager.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddNewUser(User user)
        {
            var addedUser = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return addedUser.Entity;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                var result = await _context.SaveChangesAsync();

                return result == 1;
            }

            return false;
        }

        public async Task<User> GetUserById(int id)
        {
            return (await _context.Users.FindAsync(id))!;
        }

        public async Task<User> UpdateUser(User user)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return updatedUser.Entity;
        }
    }
}
