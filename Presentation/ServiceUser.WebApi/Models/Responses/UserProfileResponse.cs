#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ServiceUser.WebApi.Models.Responses
{
    public class UserProfileResponse
    {
        [Required]
        public Guid Id { get; init; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool WalksDogs { get; set; }
        public string? Profession { get; set; }
        public string? AboutSelf { get; set; }
        public string? Interests { get; set; }
        [Required]
        public Guid AccountId { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
    }
}
