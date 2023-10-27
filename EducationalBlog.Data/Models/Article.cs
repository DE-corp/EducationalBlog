namespace EducationalBlog.Data.Models
{
    /// <summary>
    /// Статья
    /// </summary>
    public class Article
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Статья и пользователь
        public Guid User_Id { get; set; }
        public User User { get; set; }

        // Комментарий к статье
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Тэги
        public List<Tag> tags { get; set; } = new List<Tag>();
    }
}
