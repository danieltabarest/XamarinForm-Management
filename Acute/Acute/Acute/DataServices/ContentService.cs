using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Acute.Data.Interfaces;
using Acute.DataServices.Interfaces;
using Acute.Models;
using Acute.Services;
using Simedia.App.SDK;
using Simedia.App.SDK.Endpoints;

namespace Acute.DataServices
{
    public class ContentService : EndpointBase,IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IAuthenticationService _authenticationService;

        public ContentService(SimediaSDK sdk) : base(sdk)
        {
        }

        //public ContentService(IContentRepository contentRepository, IAuthenticationService authenticationService)
        //{
        //    _contentRepository = contentRepository;
        //    _authenticationService = authenticationService;
        //}

        public async Task<IEnumerable<string>> ContentForProjectAsync(string ProjectId)
        {
            return await _contentRepository.GetContentForProjectAsync(ProjectId);
        }

        public async Task<IEnumerable<string>> ContentInFolderForProjectAsync(string ProjectId, string folderId)
        {
            return await _contentRepository.GetContentInFolderForProjectAsync(ProjectId, folderId);
        }

        public async Task<Stream> FileStreamAsync(Uri fileUrl)
        {
            var pdfAsBytes = await _contentRepository.GetFileAsync(fileUrl, _authenticationService.GetEncodedCredentials());
            return new MemoryStream(pdfAsBytes);
        }

        public async Task<Stream> PdfFileStreamAsync(Uri fileUrl, string ProjectId, string contentId, string fileExtension)
        {
            var pdfAsBytes = await _contentRepository.GetDocToPdfFileAsync(fileUrl, ProjectId, contentId, fileExtension);
            return new MemoryStream(pdfAsBytes);
        }
    }
}
