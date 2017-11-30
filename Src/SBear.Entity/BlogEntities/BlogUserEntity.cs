using System;

namespace SBear.Entities.BlogEntities
{
    public class BlogUserEntity : BaseEntity
    {
        public String Nickname { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String GitHubAddress { get; set; }
    }
}
