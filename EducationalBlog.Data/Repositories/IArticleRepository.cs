using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;

namespace EducationalBlog.Data.Repositories
{
    public interface IArticleRepository
    {
        public Task CreateArticle(Article article, User user);
        public Task UpdateArticle(Article article, User user, UpdateArticleModel updateArticle);
        public Task DeleteArticle(Article article);
        public Task<Article> GetArticleById(Guid id);
        public Task<Article[]> GetArticles();
    }
}
