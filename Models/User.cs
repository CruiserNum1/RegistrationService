using System;
using Microsoft.AspNetCore.Identity;

namespace RegistrationService.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }
    }
}