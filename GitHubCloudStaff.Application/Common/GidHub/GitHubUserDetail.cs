using GitHubCloudStaff.Application.Common.Interface;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCloudStaff.Application.Common.GidHub
{
    public class GitHubUserDetail
    {
        string _login = "";
        string _name = "";
        string _company = "";
        string _followers = "";
        string _repositories = "";

        private HttpWebRequest webRequest;
        private readonly IApplicationSettings _applicationSettings;
        private IMemoryCache __cache;
        public GitHubUserDetail() {}
        public GitHubUserDetail(IApplicationSettings applicationSettings,IMemoryCache cache, string user)
        {
            _applicationSettings = applicationSettings;
            __cache = cache;
            webRequest = WebRequest.Create(_applicationSettings.ByUserDetail +  user) as HttpWebRequest;
            GetDateDetail(user);
        }
        public GitHubUserDetail(string user)
        {
           
            webRequest = WebRequest.Create(_applicationSettings.ByUserDetail + user) as HttpWebRequest;
            GetDateDetailNoCache(user);
        }

        public string Login { get { return _login; } }

        public string Name { get { return _name; } } //": 1,

        public string Company { get { return _company; } }

        public string Followers { get { return _followers; } }
        public string Repositories { get { return _repositories; } }

        protected internal  void GetDateDetail(string username)
        {
            GitHudUser _user = new GitHudUser();
            try
            {
                if (!__cache.TryGetValue(username, out _user))
                {
                    if (_user == null)
                    {
                        if (webRequest != null)
                        {
                            webRequest.Method = "GET";
                            webRequest.UserAgent = "Anything";
                            webRequest.ServicePoint.Expect100Continue = false;
                            try
                            {
                                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                                {
                                    string reader = responseReader.ReadToEnd();
                                    _user = JsonConvert.DeserializeObject<GitHudUser>(reader);
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        __cache.Set(username, _user, DateTimeOffset.UtcNow.AddMinutes(10));
                    }
                }
                if (_user != null)
                {
                    _login = username;
                    _name = _user.name;
                    _company = _user.company;
                    _followers = _user.followers;
                    _repositories = _user.repos_url;
                }
            }
            catch
            {
                _login = "";
                _name ="";
                _company = ""; 
                _followers = ""; 
                _repositories = ""; 
            }
          
        }

        protected internal void GetDateDetailNoCache(string username)
        {
            GitHudUser _user = new GitHudUser();

            try
            {
 
                if (_user == null)
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.UserAgent = "Anything";
                        webRequest.ServicePoint.Expect100Continue = false;
                        try
                        {
                            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                            {
                                string reader = responseReader.ReadToEnd();
                                _user = JsonConvert.DeserializeObject<GitHudUser>(reader);
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                      
                }
                if (_user != null)
                {
                    _login = username;
                    _name = _user.name;
                    _company = _user.company;
                    _followers = _user.followers;
                    _repositories = _user.repos_url;
                }

            }
            catch
            {
                _login = username;
                _name = "";
                _company = "";
                _followers = "";
                _repositories = "";
            }

        }




    }
}
