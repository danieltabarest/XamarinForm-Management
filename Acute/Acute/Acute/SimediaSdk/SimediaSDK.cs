using System;
using System.Collections.Generic;
using Simedia.App.SDK.Endpoints;
using Acute.Services;

namespace Simedia.App.SDK
{
    public partial class SimediaSDK
    {
        public SimediaSDK(string baseUrl)
            : this(string.Empty, string.Empty, baseUrl)
        {
        }

        public SimediaSDK(string applicationKey, string applicationSecret)
            : this(applicationKey, applicationSecret, API_BASE_URL)
        {

        }

        public SimediaSDK(string applicationKey, string applicationSecret, string baseUrl)
        {
            this.CustomHeaders = new List<KeyValuePair<string, string>>();
            //this.SignatureGenerator = new HashedTimeSignatureGenerator();

            this.AsyncTimeoutMillisecond = (int)TimeSpan.FromSeconds(40).TotalMilliseconds;
            this.ApplicationKey = applicationKey;
            this.ApplicationSecret = applicationSecret;

            if (baseUrl == null)
            {
                baseUrl = API_BASE_URL;
            }
            this.BaseUrl = baseUrl;

            this.ConstructEndpoints();
        }
        #region Constants

        public const string API_BASE_URL = "https://acute360.com";
        //public const string API_BASE_URL = "https://jsonplaceholder.typicode.com";
        protected const string API_PARAM_KEY = "api_key";
        protected const string API_PARAM_SIG = "api_signature";

        #endregion

        #region Properties

        public int AsyncTimeoutMillisecond;
        public string BaseUrl;
        public List<KeyValuePair<string, string>> CustomHeaders { get; set; }
        public string ApplicationKey; // member for web ease
        public string ApplicationSecret; // member for web ease
        //protected HashedTimeSignatureGenerator SignatureGenerator { get; set; }
        #endregion

        #region Endpoints
        public UserEndpoint Users;
        public ProjectEndpoint Projects;
        public TaskEndpoint Tasks;
        public AuthenticationService AuthenticationService;
        public ProjectsService projectsService;
        public ActivityService ActivityService;
        public TaskLogService TaskLogService;
        #endregion

        #region Protected methods

        protected virtual void ConstructEndpoints()
        {
            this.AuthenticationService = new AuthenticationService(this);
            this.projectsService = new ProjectsService(this);
            this.ActivityService = new ActivityService(this);
            this.TaskLogService = new TaskLogService(this);
            this.Users = new UserEndpoint(this);
            this.Projects = new ProjectEndpoint(this);
            this.Tasks = new TaskEndpoint(this);
        }

        #endregion

    }
}
