using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace LDI.Model
{
    public class User : Base
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EMail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string ProfileImage { get; set; }

        public DateTime LastLogin { get; set; }

        public Guid TimeStamp { get; set; }

        [JsonIgnore]
        public IList<UserChannel> UserChannels { get; set; }

        [JsonIgnore]
        public IList<UserRole> UserRoles { get; set; }
    }
}
