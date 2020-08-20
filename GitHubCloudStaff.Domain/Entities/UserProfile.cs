using GitHubCloudStaff.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.Domain.Entities
{
    public class UserProfile : User
    {
        //public UserProfile()
        //{
        //    this.Followers = new List<UserFollower>();
        //    this.Repositories = new List<UserRepository>();
        //}
        //public string Login { get; set; }
        //public string Company { get; set; }
        //public List<UserFollower> Followers { get; set; }
        //public List<UserRepository> Repositories { get; set; }
        public string Login { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Followers { get; set; }
        public string Repositories { get; set; }
    }
}
