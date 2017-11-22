using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Acute.Models;

namespace Acute.DataServices.Interfaces
{
    public interface IContentService
    {
        Task<IEnumerable<string>> ContentForProjectAsync(string ProjectId);
        Task<IEnumerable<string>> ContentInFolderForProjectAsync(string ProjectId, string folderId);
        Task<Stream> FileStreamAsync(Uri fileUrl);
        Task<Stream> PdfFileStreamAsync(Uri fileUrl, string ProjectId, string contentId, string fileExtension);
    }
}
