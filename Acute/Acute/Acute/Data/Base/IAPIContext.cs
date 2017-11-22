using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acute.Data.Base
{
    public interface IAPIContext
    {
        Task<TResource> GetResourceAsync<TResource, TJsonObject>(string uri, string exceptionMessage) 
            where TResource : class
            where TJsonObject : JsonObject<TResource>;

        Task<string> GetResourceAsync(string uri, string exceptionMessage);

        Task<IEnumerable<TResource>> GetResourcesAsync<TResource, TJsonObject>(string uri, string exceptionMessage)
            where TResource : class
            where TJsonObject : JsonObject<TResource>;

        Task<string> PostResourceAsync(string uri, string data, string exceptionMessage);
	}
}
