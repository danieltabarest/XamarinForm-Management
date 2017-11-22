using System;
using System.Collections.Generic;
using System.Text;
using Simedia.App.SDK;
using System.Threading.Tasks;
using Simedia.App.SDK.Models.Responses;
using Simedia.App.SDK.Shared;
using Simedia.App.SDK.Models;

namespace Simedia.App
{
    public interface ISimediaApp
    {
		AppConfig AppConfig { get; }
		User CurrentUser { get; }
        bool IsFirstTimeLogin { get; }
        string TempFolderPath { get; }
        string SpeechLocalization { get; }
		//IViewPlatform ViewPlatform { get; }

        string GetLocalizedText(LanguageToken token, string defaultText);

        void Initialize();

        void LogOff(bool notifyViewPlatform, bool redirect);

        Task<ItemResult<UserResponse>> LoginAsync(string username, string password, Action<bool> onProcessing = null);

        //Task<bool> ProjectsFetchAsync(bool? allowStale, bool force, int page, int page_size, DataFetchedDelegate<ListResult<Project>> onFetched, Action<bool> onFetching = null);

        //Task<bool> TasksFetchAsync(bool? allowStale, bool force, int page, int page_size, DataFetchedDelegate<ListResult<TaskObject>> onFetched, Action<bool> onFetching = null);
    }
}
