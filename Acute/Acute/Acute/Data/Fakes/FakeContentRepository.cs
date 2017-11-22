using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acute.Data.Interfaces;
using Acute.Models;

namespace Acute.Data.Fakes
{
    public class FakeContentRepository : IContentRepository
    {
        public Task<IEnumerable<string>> GetContentForProjectAsync(string ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetContentInFolderForProjectAsync(string ProjectId, string folderId)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string ProjectId, string contentId, string fileExtension)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
