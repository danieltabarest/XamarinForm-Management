using System.Net.Http;
using System.Threading.Tasks;

namespace Acute.Services
{
	public interface IAuthenticationService
	{
		Task<bool> AuthenticateAsync(string username, string password);
		void Logout();
		bool IsLoggedIn();
		string GetToken();
		string GetEncodedCredentials();
        string Username { get;}
        void SaveUsername();
        void ClearUsername();
        string SavedUsername { get; }
    }
}
