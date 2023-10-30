namespace EducationalBlog.Contracts.Models.User
{
    public class GetUserResponse
    {
        public int UsersCount { get; set; }
        public UserView[] UserView { get; set; }
    }
    public class UserView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
