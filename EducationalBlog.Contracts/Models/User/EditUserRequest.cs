namespace EducationalBlog.Contracts.Models.User
{
    public class EditUserRequest
    {
        public Guid Id { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
        public string NewLogin { get; set; }
    }
}
