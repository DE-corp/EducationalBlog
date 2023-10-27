using EducationalBlog.Data.Context;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalBlog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public BlogContext _context;

        public UserRepository(BlogContext context)
        {
            context = _context;
        }

        public async Task DeleteUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetAllUsers()
        {
            return await _context.Users
                .ToArrayAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task RegisterUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.AddAsync(entry);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user, UpdateUserModel updateUser)
        {
            if (!string.IsNullOrEmpty(updateUser.NewUserFirstName))
                updateUser.NewUserFirstName = user.FirstName;
            if (!string.IsNullOrEmpty(updateUser.NewUserLastName))
                updateUser.NewUserLastName = user.LastName;
            if (!string.IsNullOrEmpty(updateUser.NewEmail))
                updateUser.NewEmail = user.Email;
            if (!string.IsNullOrEmpty(updateUser.NewPassword))
                updateUser.NewPassword = user.Password;
            if (!string.IsNullOrEmpty(updateUser.NewLogin))
                updateUser.NewLogin = user.Login;

            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.Update(entry);

            await _context.SaveChangesAsync();
        }
    }
}
