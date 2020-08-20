using GitHubCloudStaff.Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.Application.Common
{
  
        public class ApplicationSettings : IApplicationSettings
        {
            public  string ByUser { get; set; }
            public  string ByUserDetail { get; set; }
            public  string ListCount { get; set; }

        }
     
}
