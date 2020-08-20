using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.Application.Common.Interface
{
    public interface IApplicationSettings
    {
        string ByUser { get; set; }
        string ByUserDetail { get; set; }
        string ListCount { get; set; }
    }
}
