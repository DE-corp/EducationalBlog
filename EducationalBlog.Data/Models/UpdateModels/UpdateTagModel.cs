namespace EducationalBlog.Data.Models.UpdateModels
{
    public class UpdateTagModel
    {
        public string NewTag { get; }

        public UpdateTagModel(string newTag)
        {
            NewTag = newTag;
        }
    }
}
