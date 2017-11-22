using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acute.Models;
using Acute.Data.Interfaces;
using RestSharp.Portable;
using Simedia.App.SDK;
using Acute.Models.Responses;
using Simedia.App.SDK.Endpoints;
using Acute.Data.Base;
using RestSharp.Portable.HttpClient;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using FreshMvvm;
using Acute.Data;

namespace Acute.Services
{
    public class AuthenticationService : EndpointBase, IAuthenticationService
    {
        private string _encodedCredentials;
        private readonly ISingleObjectCacheRepository<UserAccount> _userAccountRepository;
        //private readonly Authenticator _authenticator;
        private string _username;
        private string _company;
        private string _password;
        static string Token { get; set; }
        private readonly IAPIContext _apiContext;
        private readonly JsonSerializerSettings _serializerSettings;
        public AuthenticationService(SimediaSDK sdk) : base(sdk)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _userAccountRepository = new SingleObjectCacheRepository<Models.UserAccount, Data.RealmModels.UserAccount>();
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

      

        //public string Username => _username;

        public string Username { get { return _userAccountRepository.Retrieve()?.Username ?? string.Empty; } set { _username = value; } }
        public string Company { get { return _userAccountRepository.Retrieve()?.Company ?? string.Empty; } set { _company = value; } }
        

        public string SavedUsername => _userAccountRepository.Retrieve()?.Username ?? string.Empty;

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var responseData = string.Empty;
            var success = false;
            _username = username;
            _password = password;
            success = false;

            _encodedCredentials = EncodeCredentials(username, password);
            try
            {

                string sUrl = "https://acute360.com/WS/1/session";
                string sContentType = "application/json"; // or application/xml
                JObject oJsonObject = new JObject();
                oJsonObject.Add("email", username);
                oJsonObject.Add("password", password);
                HttpClient oHttpClient = new HttpClient();
                var oTaskPostAsync = await oHttpClient.PostAsync(sUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));
                responseData = await oTaskPostAsync.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<User>(responseData, _serializerSettings);
                _company = result.companyInfo.name;
                Token = result.token;
                if (oTaskPostAsync.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    throw new Exception(oTaskPostAsync.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                // Log exception.
                throw new Exception("Something went wrong while attempting to authenticate. Please contact the system administrator.", ex);
            }
            return success;
        }

        public void Logout()
        {
            //_authenticator.Logout();
            _username = string.Empty;
        }

        public string GetToken()
        {
            return Token;
        }

        public string GetEncodedCredentials()
        {
            return _encodedCredentials ?? string.Empty;
        }

        public bool IsLoggedIn()
        {
            return false; //return _authenticator.IsLoggedIn;
        }

        private string EncodeCredentials(string username, string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{username}:{password}");
            return Convert.ToBase64String(plainTextBytes);
        }

        public void SaveUsername()
        {
            _userAccountRepository.Update(new UserAccount(_username, _company), _username);
        }


        public void ClearUsername()
        {
            //if (!string.IsNullOrWhiteSpace(_userAccountRepository?.Retrieve()?.Username))
            //    _userAccountRepository.Update(new UserAccount(string.Empty), string.Empty);
        }
    }
}
