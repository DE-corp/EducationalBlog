namespace EducationalBlog.Data.Models
{
    /// <summary>
    /// Тэг
    /// </summary>
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // Привязка со статьей "многие ко многим"
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
