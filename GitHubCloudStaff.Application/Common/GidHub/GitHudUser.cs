using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.Application.Common.GidHub
{

    public class GitHudUser : GitHudUserList
    {

        public string name { get; set; }  
        public string company { get; set; }   
        public string followers { get; set; } 
        public string repos_url { get; set; } 

    }
}
