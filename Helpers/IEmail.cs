namespace ProjectMVCv._2.Helpers
{
    public interface IEmail
    {
        bool SendEmail(string email, string about, string message);
    }
}
