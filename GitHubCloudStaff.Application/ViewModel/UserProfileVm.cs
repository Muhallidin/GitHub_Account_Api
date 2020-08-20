using GitHubCloudStaff.Application.Common.GidHub;
using GitHubCloudStaff.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCloudStaff.Application.ViewModel
{
    public class UserProfileVm 
    {

        public string Login { get;set;  }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Followers { get; set; }
        public string Repositories { get; set; }


    }
}

