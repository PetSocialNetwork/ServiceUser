using ServiceUser.Domain.Interfaces;

namespace ServiceUser.Domain.Entities
{
    public class UserProfile : IEntity
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
        public bool IsProfileCompleted { get; set; }
        public UserProfile(Guid id, Guid accountId)
        {
            Id = id;
            AccountId = accountId;  
        }
        protected UserProfile() { }
    }
}
