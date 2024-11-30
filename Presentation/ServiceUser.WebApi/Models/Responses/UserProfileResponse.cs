﻿namespace ServiceUser.WebApi.Models.Responses
{
    public class UserProfileResponse
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public string? Education { get; set; } TODO
        public bool WalksDogs { get; set; }
        public string? Profession { get; set; }
        public Guid? PetId { get; set; } //TODO: может быть много
        public Guid AccountId { get; set; }

        //TODO: в последствии добавить фотографии
    }
}