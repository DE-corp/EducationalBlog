namespace EducationalBlog.Contracts.Models.Comments
{
    public class AddCommentReqest
    {
        public Guid Id { get; set; }
        public string CommentContext { get; set; }
    }
}
