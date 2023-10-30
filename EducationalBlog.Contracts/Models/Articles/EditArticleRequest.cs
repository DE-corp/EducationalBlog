namespace EducationalBlog.Contracts.Models.Articles
{
    public class EditArticleRequest
    {
        public Guid Id { get; set; }
        public string NewArticleName { get; set; }
        public string NewArticleContext { get; set; }
    }
}
