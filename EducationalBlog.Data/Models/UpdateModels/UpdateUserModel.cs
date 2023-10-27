namespace EducationalBlog.Data.Models.UpdateModels
{
    public class UpdateUserModel
    {
        public string NewUserFirstName { get; set; }
        public string NewPassword { get; set; }
        public string NewEmail { get; set; }
        public string NewUserLastName { get; set; }
        public string NewLogin { get; set; }
        public UpdateUserModel(string newUserFirstName, string newPassword, string newEmail, string newUserLastName, string newLogin)
        {
            NewUserFirstName = newUserFirstName;
            NewPassword = newPassword;
            NewEmail = newEmail;
            NewUserLastName = newUserLastName;
            NewLogin = newLogin;
        }
    }
}
