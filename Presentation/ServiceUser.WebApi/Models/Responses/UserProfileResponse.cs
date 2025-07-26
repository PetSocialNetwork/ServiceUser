#pragma warning disable CS8618

namespace ServiceUser.WebApi.Models.Responses
{
    public class UserProfileResponse
    {
        public Guid Id { get; init; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool WalksDogs { get; set; }
        public string? Profession { get; set; }
        public string? AboutSelf { get; set; }
        public string? Interests { get; set; }
        public Guid AccountId { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
    }
}
