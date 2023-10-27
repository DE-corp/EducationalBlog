using EducationalBlog.Data.Context;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalBlog.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public BlogContext _context;
        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task CreateArticle(Article article, User user)
        {
            article.User_Id = user.Id;

            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                _context.AddAsync(article);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticle(Article article)
        {
            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                _context.Remove(article);

            await _context.SaveChangesAsync();
        }

        public async Task<Article> GetArticleById(Guid id)
        {
            return await _context.Articles
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<Article[]> GetArticles()
        {
            return await _context.Articles
                .ToArrayAsync();
        }

        public async Task UpdateArticle(Article article, User user, UpdateArticleModel updateArticle)
        {
            article.User_Id = user.Id;

            if (!string.IsNullOrEmpty(updateArticle.NewContent))
                article.Content = updateArticle.NewContent;
            if (!string.IsNullOrEmpty(updateArticle.NewName))
                article.Name = updateArticle.NewName;

            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                _context.Update(article);

            await _context.SaveChangesAsync();
        }
    }
}
