#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ServiceUser.WebApi.Models.Requests
{
    public class FindUserProfileRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
