using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Acute.Data.Base;
using Acute.Data.Interfaces;


using Acute.Models;
//using RestSharp.Portable;
//using RestSharp.Portable.HttpClient;

namespace Acute.Data
{
    public class ContentRepository : IContentRepository
    {
        private readonly IAPIContext _apiContext;

        public ContentRepository(IAPIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<IEnumerable<string>> GetContentForProjectAsync(string ProjectId)
        {
            var uri = $"learning/ProjectData/content/tableofcontent/withcontent?ProjectId={ProjectId}";
            var exceptionMessage = $"There was error while attempting to get content for Project with id: {ProjectId}";
            return null;
            //return await _apiContext.GetResourcesAsync<Content, ContentDto>(uri, exceptionMessage);
		}

        public async Task<IEnumerable<string>> GetContentInFolderForProjectAsync(string ProjectId, string folderId)
        {
			var uri = $"learning/ProjectData/content/children/Project/{ProjectId}/content/{folderId}";
			var exceptionMessage = $"There was error while attempting to get content for Project with id: {ProjectId} in folder: {folderId}.";
            return null;
            //return await _apiContext.GetResourcesAsync<Content, ContentDto>(uri, exceptionMessage);
        }

        public async Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string ProjectId, string contentId, string fileExtension)
        {
            var uri = $"learning/ProjectData/content/aspdf?document={fileUrl}&ProjectId={ProjectId}&contentId={contentId}&fileType={fileExtension}";
            var message = $"There was error while attempting to retrieve converted PDF for document at {fileUrl}.";
            var pdfAsText = string.Empty;

            try
            {
                pdfAsText = await _apiContext.GetResourceAsync(uri, message);
            }
	
			catch (System.Net.Http.HttpRequestException ex)
			{
				//if (ex.Message == "404 (Not Found)")
				//	throw new Exceptions.FileNotFoundException($"The file at {fileUrl} cannot be found.", ex);
				//else
				//	throw new FileErrorException($"There was an error while attemping to get the bytes for the file at {fileUrl}", ex);
			}
			catch (Exception ex)
			{
				//throw new DataRepositoryException($"There was an error while attempting to get the file at {fileUrl}", ex);
			}

            return Convert.FromBase64String(pdfAsText);
        }

        public Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials)
        {
            throw new NotImplementedException();
        }

        /*public async Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials)
        {
			IRestResponse response = null;

			try
			{
				using (var client = new RestClient(fileUrl))
				{
					var request = new RestRequest(Method.GET);
					request.AddHeader("cache-control", "no-cache");
					request.AddHeader("authorization", $"Basic {base64EncodedCredentials}");

					response = await client.Execute(request);
				}
			}
            //catch(InternetConnectionException)
            //{
            //    throw;
            //}
            catch(System.Net.Http.HttpRequestException ex)
            {
                //if (ex.Message == "404 (Not Found)")
                //    throw new Exceptions.FileNotFoundException($"The file at {fileUrl} cannot be found.", ex);
                //else
                //    throw new FileErrorException($"There was an error while attemping to get the bytes for the file at {fileUrl}", ex);
            }
			catch (Exception ex)
			{
                //throw new DataRepositoryException($"There was an error while attempting to get the file at {fileUrl}", ex);
			}

            return response.RawBytes;
        }*/
    }
}
