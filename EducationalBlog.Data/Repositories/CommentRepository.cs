using EducationalBlog.Data.Context;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalBlog.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        public BlogContext _context;
        public CommentRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task CreateComment(Comment comment, User user, Article article)
        {
            comment.User_Id = user.Id;
            comment.Article_Id = article.Id;

            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                await _context.Comments.AddAsync(comment);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();
        }

        public async Task<Comment[]> GetAllComments()
        {
            return await _context.Comments
                .ToArrayAsync();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _context.Comments
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateComment(Comment comment, UpdateCommentModel updateComment)
        {
            if (!string.IsNullOrEmpty(updateComment.NewContent))
                comment.Content = updateComment.NewContent;

            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Comments.Update(comment);

            await _context.SaveChangesAsync();
        }
    }
}
