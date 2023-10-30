namespace EducationalBlog.Data.Models
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Комментарий к пользователю
        public Guid User_Id { get; set; }
        public User User { get; set; }


        // Комментарий к статье
        public Guid Article_Id { get; set; }
        public Article Article { get; set; }
    }
}
