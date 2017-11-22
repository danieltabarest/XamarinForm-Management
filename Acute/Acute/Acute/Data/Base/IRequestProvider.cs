using System.Threading.Tasks;

namespace Acute.Data.Base
{
    public interface IRequestProvider
    {
		Task<TResult> GetAsync<TResult>(string uri);
        Task<string> PostAsync(string uri, string data);
		Task<TResult> PostAsync<TResult>(string uri, TResult data);
		Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data);
		Task<TResult> PutAsync<TResult>(string uri, TResult data);
		Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data);
    }
}
