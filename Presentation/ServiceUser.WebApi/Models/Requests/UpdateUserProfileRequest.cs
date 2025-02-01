#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ServiceUser.WebApi.Models.Requests
{
    public class UpdateUserProfileRequest
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public string? Education { get; set; } TODO
        public bool WalksDogs { get; set; }
        public string? Profession { get; set; }
        public Guid AccountId { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
    }
}
