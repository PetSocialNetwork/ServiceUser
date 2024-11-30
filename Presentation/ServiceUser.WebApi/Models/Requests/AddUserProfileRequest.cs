using System.ComponentModel.DataAnnotations;

namespace ServiceUser.WebApi.Models.Requests
{
    public class AddUserProfileRequest
    {
        [Required]
        public Guid AccountId { get; set; }
    }
}
