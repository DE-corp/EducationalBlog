namespace EducationalBlog.Contracts.Models.Comments
{
    public class EditCommentReqest
    {
        public Guid Id { get; set; }
        public string NewContent { get; set; }
    }
}
