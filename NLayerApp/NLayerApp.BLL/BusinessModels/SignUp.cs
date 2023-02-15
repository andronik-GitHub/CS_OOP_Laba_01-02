namespace NLayerApp.BLL.BusinessModels
{
    public class SignUp
    {
        public int Id;
        public string NikName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string AboutMyself { get; set; } = string.Empty;
        public string RegistrationDate { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
