namespace EducationalBlog.Data.Models.UpdateModels
{
    public class UpdateArticleModel
    {
        public string NewContent { get; } = string.Empty;
        public string NewName { get; } = string.Empty;

        public UpdateArticleModel(string newContent, string newName)
        {
            NewContent = newContent;
            NewName = newName;
        }
    }
}
