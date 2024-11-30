using System.ComponentModel.DataAnnotations;

namespace ServiceUser.WebApi.Models.Requests
{
    public class UpdatedUserProfileRequest
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public string? Education { get; set; } TODO
        public bool WalksDogs { get; set; }
        public string? Profession { get; set; }
        public Guid? PetId { get; set; }
        public Guid AccountId { get; set; }
        //TODO: в последствии добавить фотографии
    }
}
