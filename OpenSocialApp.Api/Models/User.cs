using System;

namespace OpenSocialApp.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmailCheckResponse
    {
        public bool Res { get; set; }
    }

    public class EmailCheckRequest
    {
        public string EmailAddress { get; set; }
    }

    public class SignUpRequest {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}