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
            _context = context;
        }

        public async Task DeleteUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.Users.Remove(user);

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

        public async Task CreateUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user, UpdateUserModel updateUser)
        {
            if (!string.IsNullOrEmpty(updateUser.NewUserFirstName))
                user.FirstName = updateUser.NewUserFirstName;
            if (!string.IsNullOrEmpty(updateUser.NewUserLastName))
                user.LastName = updateUser.NewUserLastName;
            if (!string.IsNullOrEmpty(updateUser.NewEmail))
                user.Email = updateUser.NewEmail;
            if (!string.IsNullOrEmpty(updateUser.NewPassword))
                user.Password = updateUser.NewPassword;
            if (!string.IsNullOrEmpty(updateUser.NewLogin))
                user.Login = updateUser.NewLogin;

            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
