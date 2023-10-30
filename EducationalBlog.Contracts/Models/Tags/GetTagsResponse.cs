namespace EducationalBlog.Contracts.Models.Tags
{
    public class GetTagsResponse
    {
        public int TegAmount { get; set; }
        public TagView[] TagViews { get; set; }
    }
    public class TagView
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
