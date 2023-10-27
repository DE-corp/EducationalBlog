using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;

namespace EducationalBlog.Data.Repositories
{
    public interface IUserRepository
    {
        public Task RegisterUser(User user);
        public Task UpdateUser(User user, UpdateUserModel updateUser);
        public Task DeleteUser(User user);
        public Task<User[]> GetAllUsers();
        public Task<User> GetUserById(Guid id);
    }
}
