namespace EducationalBlog.Data.Models.UpdateModels
{
    public class UpdateCommentModel
    {
        public string NewContent { get; } = string.Empty;
        public UpdateCommentModel(string newContent)
        {
            NewContent = newContent;
        }
    }
}
