#pragma warning disable CS8618

namespace ServiceUser.WebApi.Models.Requests
{
    public class FindUserProfileRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PaginationRequest Options { get; set; }
    }
}
