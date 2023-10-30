namespace EducationalBlog.Contracts.Models.Comments
{
    public class GetCommentsResponse
    {
        public int CommentAmount { get; set; }
        public CommentView[] commentViews { get; set; }
    }
    public class CommentView
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
