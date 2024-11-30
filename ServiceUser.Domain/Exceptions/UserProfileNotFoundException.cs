namespace ServiceUser.Domain.Exceptions
{
    public class UserProfileNotFoundException : DomainException
    {
        public UserProfileNotFoundException(string? message) : base(message)
        {
        }

        public UserProfileNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
