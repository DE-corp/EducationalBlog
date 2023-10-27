using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;

namespace EducationalBlog.Data.Repositories
{
    public interface ICommentRepository
    {
        public Task CreateComment(Comment comment, User user, Article article);
        public Task UpdateComment(Comment comment, UpdateCommentModel updateComment);
        public Task DeleteComment(Comment comment);
        public Task<Comment[]> GetAllComments();
        public Task<Comment> GetCommentById(Guid id);
    }
}
