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
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Net.Http.Headers;

namespace Acute.Services
{
    public class ProjectsService : EndpointBase

    {
        private readonly IProjectRepository _ProjectRepository;
        //private readonly ITermsService _termsService;
        private Dictionary<string, string> _nameCache = new Dictionary<string, string>();
        private readonly DateTime _targetDate = DateTime.Now;
        private readonly Uri _baseUri = new Uri("https://acute360.com/WS/1/text");
        //public ProjectsService(IProjectRepository ProjectRepository)
        //{
        //    _ProjectRepository = ProjectRepository;
        //}

        public ProjectsService(SimediaSDK sdk) : base(sdk)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<Project> ProjectAsync(string ProjectId)
        {
            return await _ProjectRepository.GetProjectAsync(ProjectId);
        }
        private readonly JsonSerializerSettings _serializerSettings;
        public async Task<Text> ActiveProjectsAsync()
        {
            var serialized = string.Empty;
            try
            {
                string sUrl = "https://acute360.com/WS/1/text";
                var httpClient = CreateHttpClient();
                var response = await httpClient.GetAsync(sUrl);
                await HandleResponse(response);
                serialized = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return await Task.Run(() => JsonConvert.DeserializeObject<Text>(serialized, _serializerSettings));
        }

        public async Task<object> GetAsync(string uri)
        {
            var serialized = string.Empty;

            try
            {
                var httpClient = CreateHttpClient();
                var response = await httpClient.GetAsync(uri);

                await HandleResponse(response);

                serialized = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                //if (ex.InnerException is System.Net.WebException)
                //    throw new InternetConnectionException(ex.Message);
                //else
                //    throw;
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.Run(() => JsonConvert.DeserializeObject<object>(serialized, _serializerSettings));
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = _baseUri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.Sdk.AuthenticationService.GetToken());
            return httpClient;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    // throw new AuthenticationException(content);
                }

                //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //    throw new AuthenticationException(content);

                throw new HttpRequestException(content);
            }
        }

        //public async Task<IEnumerable<Project>> ActiveTrainingProjectsAsync()
        //{
        //    return (await TrainingProjectsAsync(_targetDate)).ToList();
        //}

        //public async Task<IEnumerable<Project>> ActiveAcademicProjectsAsync()
        //{
        //    return (await AcademicProjectsAsync(_targetDate)).ToList();
        //}

        //public async Task<int> ActiveProjectsCountAsync()
        //{
        //    return (await ProjectsAsync(_targetDate)).Count();
        //}

        //public async Task<string> ProjectNameByIdAsync(string ProjectId)
        //{
        //    string name = "";
        //    var existsInCache = _nameCache.TryGetValue(ProjectId, out name);

        //    if (!existsInCache)
        //    {
        //        var Project = await ProjectAsync(ProjectId);
        //        name = Project?.data ?? "Unassigned";
        //        _nameCache[ProjectId] = name;
        //    }

        //    return name;
        //}

        //private async Task<IEnumerable<Project>> ProjectsAsync(DateTime targetDate)
        //{
        //    var ProjectsQuery = await _ProjectRepository.GetProjectsAsync(targetDate);

        //    ProjectsQuery = await Task.WhenAll(ProjectsQuery.Select(async c =>
        //    {
        //        await AssignTerm(c);
        //        AssignListGroup(c);

        //        return c;
        //    }));

        //    return ProjectsQuery;
        //}



        //private async Task<IEnumerable<Project>> TrainingProjectsAsync(DateTime targetDate)
        //{
        //    //return (await ProjectsAsync(targetDate)).Where(c => c.ProjectType == ProjectType.TrainingProject);
        //}

        //private async Task<IEnumerable<Project>> AcademicProjectsAsync(DateTime targetDate)
        //{
        //    return (await ProjectsAsync(targetDate)).Where(c => c.ProjectType == ProjectType.AcademicProject);
        //}
    }

}
