using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.DTOS
{
    public class UserDtos
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
    }
}
