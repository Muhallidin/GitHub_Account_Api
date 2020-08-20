using GitHubCloudStaff.Application.Common.GidHub;
using GitHubCloudStaff.Application.Common.Interface;
using GitHubCloudStaff.Application.ViewModel;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GitHubCloudStaff.Application.Users.Action
{
   
    public static class FetchGitHubUser
    {

     
        internal static IList<UserProfileVm> GetGitHubUser(IApplicationSettings _applicationSettings,  IMemoryCache _cache)
        {
            HttpWebRequest _webRequest = WebRequest.Create(_applicationSettings.ByUser) as HttpWebRequest;

            IList<GitHudUserList> user = new List<GitHudUserList>();
            IList<UserProfileVm> userProfileVm = new List<UserProfileVm>();

            if (!_cache.TryGetValue("GitHudUserList", out user))
            {
                if (user == null)
                {
                    if (_webRequest != null)
                    {
                        _webRequest.Method = "GET";
                        _webRequest.UserAgent = "Anything";
                        _webRequest.ServicePoint.Expect100Continue = false;
                        try
                        {
                            using (StreamReader responseReader = new StreamReader(_webRequest.GetResponse().GetResponseStream()))
                            {
                                string reader = responseReader.ReadToEnd();
                                user = JsonConvert.DeserializeObject<List<GitHudUserList>>(reader);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                _cache.Set("GitHudUserList", user, DateTimeOffset.UtcNow.AddMinutes(2));
            }

            GitHubUserDetail usr = new GitHubUserDetail();
            foreach (GitHudUserList i in user.OrderBy(e => e.login).Take(Convert.ToInt32(_applicationSettings.ListCount)))
            {

                usr = new GitHubUserDetail(_applicationSettings, _cache, i.login);
                userProfileVm.Add(new UserProfileVm
                {
                    Company = usr.Company,
                    Followers = usr.Followers,
                    Login = usr.Login,
                    Name = usr.Name,
                    Repositories = usr.Repositories,
                });

            }
            return userProfileVm.OrderBy(e => e.Name).Select(e => e).ToList();
        }

        internal  static IList<UserProfileVm> GetGitHubUserDetail(IApplicationSettings _applicationSettings, IMemoryCache _cache,string userName)
        {
            IList<UserProfileVm> userProfileVms = new List<UserProfileVm>();
            GitHubUserDetail usr = new GitHubUserDetail();
            usr = new GitHubUserDetail(_applicationSettings, _cache, userName);
            if (usr.Login != "")
            {
                userProfileVms.Add(new UserProfileVm
                {
                    Company = usr.Company,
                    Followers = usr.Followers,
                    Login = usr.Login,
                    Name = usr.Name,
                    Repositories = usr.Repositories,
                });
            }

            return userProfileVms;
        }




        public static IList<UserProfileVm> GetGitHubUserTest(string url, IMemoryCache _cache)
        {
            
            IList<UserProfileVm> userProfileVm = new List<UserProfileVm>();

            userProfileVm.Add(new UserProfileVm()
            {

                Login = "anotherjesse",
                Name = "Jesse Andrews",
                Company = "Planet Labs",
                Followers = "156",
                Repositories = "https://api.github.com/users/anotherjesse/repos"

            });

            userProfileVm.Add(new UserProfileVm()
            {
                Login = "brynary",
                Name = "Bryan Helmkamp",
                Company = "Code Climate",
                Followers= "623",
                Repositories= "https://api.github.com/users/brynary/repos"
            });

            userProfileVm.Add(new UserProfileVm()
            {

                Login = "bmizerany",
                Name = "Blake Mizerany",
                Company = null,
                Followers = "1268",
                Repositories = "https://api.github.com/users/bmizerany/repos"

            });

            userProfileVm.Add(new UserProfileVm()
            {
                Login = "atmos",
                Name = "Corey Donohoe",
                Company = null,
                Followers = "1187",
                Repositories = "https://api.github.com/users/atmos/repos"
            });

            userProfileVm.Add(new UserProfileVm()
            {
                Login = "caged",
                Name = "Justin Palmer",
                Company = "labratrevenge",
                Followers = "2132",
                Repositories = "https://api.github.com/users/caged/repos"
            });
         
            //List order y UserName
            return userProfileVm.OrderBy(e => e.Name).Select(e => e).ToList();

        }
        
    }
}
