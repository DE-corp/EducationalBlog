namespace EducationalBlog.Contracts.Models.Tags
{
    public class EditTagRequest
    {
        public Guid Id { get; set; }
        public string NewValue { get; set; }
    }
}
