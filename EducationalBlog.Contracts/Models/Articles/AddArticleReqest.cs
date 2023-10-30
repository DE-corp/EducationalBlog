namespace EducationalBlog.Contracts.Models.Articles
{
    public class AddArticleReqest
    {
        public Guid Id { get; set; }
        public string ArticleName { get; set; }
        public string ArticlContext { get; set; }
    }
}
