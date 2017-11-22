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
using Acute.DataServices.Interfaces.Models;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;

namespace Acute.Services
{
    public class TaskLogService : EndpointBase

    {
        private readonly IProjectRepository _ProjectRepository;
        private Dictionary<string, string> _nameCache = new Dictionary<string, string>();
        private readonly DateTime _targetDate = DateTime.Now;
        private readonly Uri _baseUri = new Uri("https://acute360.com/WS/1/text");

        public TaskLogService(SimediaSDK sdk) : base(sdk)
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
        public async Task<TaskLog> ActiveTaskLogAsync()
        {
            var responseData = string.Empty;
            TaskLog result = null;
            try
            {
                string sUrl = "https://acute360.com/WS/1/my-tasklogs";
                result = await this.GetAsync<TaskLog>(sUrl);
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
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

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
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

        private HttpClient CreateHttpClientPost()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = _baseUri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.Sdk.AuthenticationService.GetToken());
            return httpClient;
        }

        private HttpClient CreateHttpClientPostAttach()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = _baseUri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
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



        public async Task<TaskLog> TaskLogByActivityAsync(string activityid)
        {
            string sUrl = "https://acute360.com/WS/1/my-tasklogs?filter[activity]=" + activityid;
            var responseData = string.Empty;
            TaskLog result = null;
            try
            {
                result = await this.GetAsync<TaskLog>(sUrl);
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<GetJsonTasklog> CreateTaskLogAsync(JsonTaskLog datatasklog)
        {
            string sUrl = "https://acute360.com/WS/1/my-tasklogs";
            var responseData = string.Empty;
            bool result = false;
            GetJsonTasklog tasklog = new GetJsonTasklog();
            try
            {
                var json = JsonConvert.SerializeObject(datatasklog);
                var content = new StringContent(json, Encoding.UTF8, "application/vnd.api+json");
                var response = await this.PostAsync(sUrl, content);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = false;
                    tasklog = null;
                }
                else
                {
                    var responsestr = response.Content.ReadAsStringAsync().Result;
                    tasklog = JsonConvert.DeserializeObject<GetJsonTasklog>(responsestr, _serializerSettings);
                    result = true;
                }


            }
            catch (HttpRequestException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return tasklog;
        }


        public async Task<bool> UpdateTaskLogAsync(JsonTaskLogEdit datatasklog)
        {
            string sUrl = "https://acute360.com/WS/1/my-tasklogs/" + datatasklog.data.id;
            var responseData = string.Empty;
            bool result = false;
            try
            {
                var json = JsonConvert.SerializeObject(datatasklog);
                var content = new StringContent(json, Encoding.UTF8, "application/vnd.api+json");
                var response = await this.PatchAsync(sUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }

        public async Task<bool> UpdateValidationActivityAsync(JsonActivityEdit datatasklog)
        {
            string sUrl = "https://acute360.com/WS/1/my-activities/" + datatasklog.data.id;
            var responseData = string.Empty;
            bool result = false;
            try
            {
                var json = JsonConvert.SerializeObject(datatasklog);
                var content = new StringContent(json, Encoding.UTF8, "application/vnd.api+json");
                var response = await this.PatchAsync(sUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }
        public async Task<List<JsonAttach>> AddattachAsync(ObservableCollection<Attachment> attach, string cookie)
        {
            try
            {
                string sUrl = "https://acute360.com/WS/1/attachments";
                //var responseData = string.Empty;
                //var json = JsonConvert.SerializeObject(model);
                //var content = new StringContent(json, Encoding.UTF8, "application/vnd.api+json");
                var listattach = new System.Collections.Generic.List<JsonAttach>();
                JsonAttach resp = new JsonAttach();
                foreach (var item in attach)
                {
                    try
                    {
                        resp = await UploadImage(sUrl, item.dataArray, item.name);
                        listattach.Add(resp);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                //var result = JsonConvert.DeserializeObject<Object>(resp);

                return listattach;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> AddattachTaskLogAsync(JsonAttachmentsSave jsonAttachments, ObservableCollection<Attachment> attach, int idtasklog, string cookie)
        {
            string sUrl = "https://acute360.com/WS/1/my-tasklogs/" + idtasklog + "/relationships/attachments";
            var responseData = string.Empty;

            bool result = false;
            try
            {
                var json = JsonConvert.SerializeObject(jsonAttachments);
                var content = new StringContent(json, Encoding.UTF8, "application/vnd.api+json");
                var response = await this.PostAsync(sUrl, content);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }
        private async Task<JsonAttach> UploadImage(string url, byte[] file, string paramName)
        {
            //variable
            //var url = "http://hallpassapi.jamsocialapps.com/api/profile/UpdateProfilePicture/";
            //var file = "path/to/file.ext";
            try
            {

                JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    NullValueHandling = NullValueHandling.Ignore
                };
                _serializerSettings.Converters.Add(new StringEnumConverter());
                //read file into upfilebytes array
                var upfilebytes = file;/*File.ReadAllBytes(file)*/;

                //create new HttpClient and MultipartFormDataContent and add our file, and StudentId
                //HttpClient client = new HttpClient();
                var httpClient = CreateHttpClientPostAttach();


                MultipartFormDataContent content = new MultipartFormDataContent();
                ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
                StringContent descriptioncontent = new StringContent("1");
                content.Add(baContent, "file", paramName);
                content.Add(descriptioncontent, "description");

                //upload MultipartFormDataContent content async and store response in response var
                var response = await httpClient.PostAsync(url, content);

                //read response result as a string async into json var
                var responsestr = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<JsonAttach>(responsestr, _serializerSettings);

                return result;


            }
            catch (Exception e)
            {
                //debug

                return null;
            }
        }


        public static async Task<string> PostMultiPartForm(string url, byte[] file, string paramName, string contentType, Dictionary<String, string> nvc,
        string cookie)
        {
            // log.Debug(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.Headers["Cookie"] = cookie;
            //wr.KeepAlive = true;
            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = await wr.GetRequestStreamAsync();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            rs.Write(file, 0, file.Length);


            byte[] trailer = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            //rs.Close();
            string responseString = String.Empty;
            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream respStream = wresp.GetResponseStream();
                StreamReader respReader = new StreamReader(respStream);
                responseString = respReader.ReadToEnd();
                //log.Debug(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
            }
            catch (Exception ex)
            {
                //log.Error("Error uploading file", ex);
                if (wresp != null)
                {
                    //wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            return responseString;

        }

        public async Task<HttpResponseMessage> PatchAsync(string uri, StringContent data)
        {
            HttpResponseMessage valueresponse = null;

            //var responseData = string.Empty;
            try
            {
                var httpClient = CreateHttpClientPost();

                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, uri)
                {
                    Content = data
                };
                HttpResponseMessage response = new HttpResponseMessage();
                valueresponse = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (HttpRequestException ex)
            {
                //if (ex.InnerException is System.Net.WebException)
                //throw new InternetConnectionException(ex.Message);
                //else
                //    throw;
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.Run(() => valueresponse);
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, StringContent data)
        {
            HttpResponseMessage response = null;

            //var responseData = string.Empty;
            try
            {
                var httpClient = CreateHttpClientPost();
                response = await httpClient.PostAsync(uri, data);
                if (response.IsSuccessStatusCode)
                {

                }

                //var responsestr = response.Content.ReadAsStringAsync().Result;
                //var result = JsonConvert.DeserializeObject<TaskLog>(responsestr, _serializerSettings);
                //request.AddJsonBody(data);
                //IRestResponse response = await client.Execute(request);
                //responseData = response.Content;
            }
            catch (HttpRequestException ex)
            {
                //if (ex.InnerException is System.Net.WebException)
                //throw new InternetConnectionException(ex.Message);
                //else
                //    throw;
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.Run(() => response);
        }

        private RestClient CreateRestClient(Uri Uris)
        {
            return new RestClient
            {
                BaseUrl = Uris
            };
        }

        private RestRequest CreateRequest(string uri, Method method)
        {
            var request = new RestRequest(uri, method);
            request.Parameters.Clear();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-typw", "application/vnd.api+json");
            request.AddHeader("authorization", "Bearer " + this.Sdk.AuthenticationService.GetToken());
            return request;
        }
    }

}
