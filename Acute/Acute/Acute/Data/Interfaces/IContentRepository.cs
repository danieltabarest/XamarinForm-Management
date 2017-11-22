using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Acute.Models;

namespace Acute.Data.Interfaces
{
    public interface IContentRepository
    {
        Task<IEnumerable<string>> GetContentForProjectAsync(string ProjectId);
        Task<IEnumerable<string>> GetContentInFolderForProjectAsync(string ProjectId, string folderId);
        Task<byte[]> GetFileAsync(Uri fileUrl, string base64EncodedCredentials);
        Task<byte[]> GetDocToPdfFileAsync(Uri fileUrl, string ProjectId, string contentId, string fileExtension);
    }
}
