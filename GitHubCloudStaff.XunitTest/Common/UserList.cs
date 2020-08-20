using GitHubCloudStaff.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.XunitTest.Common
{
    public  class UserList
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Followers { get; set; }
        public string Repositories { get; set; }

        public static IList<UserList> GetList()
        {


            var lst = new List<UserList>();


            lst.Add(new UserList()
            {

                Login = "anotherjesse",
                Name = "Jesse Andrews",
                Company = "Planet Labs",
                Followers = "156",
                Repositories = "https://api.github.com/users/anotherjesse/repos"

            });

            lst.Add(new UserList()
            {
                Login = "atmos",
                Name = "Corey Donohoe",
                Company = null,
                Followers = "1187",
                Repositories = "https://api.github.com/users/atmos/repos"
            });

            lst.Add(new UserList()
            {

                Login = "bmizerany",
                Name = "Blake Mizerany",
                Company = null,
                Followers = "1268",
                Repositories = "https://api.github.com/users/bmizerany/repos"

            });

            lst.Add(new UserList()
            {
                Login = "brynary",
                Name = "Bryan Helmkamp",
                Company = "Code Climate",
                Followers = "623",
                Repositories = "https://api.github.com/users/brynary/repos"
            });

            lst.Add(new UserList()
            {
                Login = "caged",
                Name = "Justin Palmer",
                Company = "labratrevenge",
                Followers = "2132",
                Repositories = "https://api.github.com/users/caged/repos"
            });

            return lst;

            
        
        }


    }

    
}
