namespace EducationalBlog.Data.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        // Статью к пользователю
        public List<Article> Articles { get; set; } = new List<Article>();

        // Комментарий к пользователю
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
