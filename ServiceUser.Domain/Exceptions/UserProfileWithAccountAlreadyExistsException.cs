namespace ServiceUser.Domain.Exceptions
{
    public class UserProfileWithAccountAlreadyExistsException : DomainException
    {
        public UserProfileWithAccountAlreadyExistsException(string? message) : base(message)
        {
        }

        public UserProfileWithAccountAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
