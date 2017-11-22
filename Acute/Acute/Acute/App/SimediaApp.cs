using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Acute.Models;

namespace Simedia.App.App
{
 /*   public class SimediaApp : BaseClass, ISimediaApp
    {
        #region Constructor
        public SimediaApp(IViewPlatform platform, string apiBaseUrl, ICacheHost cacheHost, IDataCache dataCache, string tempFolderPath, string speechLocalization)
            : base("SimediaApp")
        {
            this.ViewPlatform = platform;
            this.ApiBaseUrl = apiBaseUrl;
            this.CacheHost = cacheHost;
            this.DataCache = dataCache;
            this.TempFolderPath = tempFolderPath;
            this.AppConfig = new AppConfig();
            this.SpeechLocalization = speechLocalization;
        }
		#endregion

		#region Constants

		private const string CACHE_FILENAME_APP_CONFIG = "app_config.cache";
		private const string CACHE_FILENAME_APP_PREFS = "app_prefs.cache";
		private const string CACHE_FILENAME_INSTALL_ID = "install.guid";
		private const string CACHE_FILENAME_USER_CACHE = "user_mem.cache";
        private const string CACHE_FILENAME_USER_RESPONSE = "user_mem.response";

		#endregion

		#region Public app methods

		public void Initialize()
        {
            base.ExecuteMethod("Initialize", delegate ()
            {
				this.AppPreferences = this.CacheHost.PersistentDataGet<AppPreferences>(false, CACHE_FILENAME_APP_PREFS);
				if (this.AppPreferences == null)
				{
					this.AppPreferences = new AppPreferences();
				}

#if !DEBUG
                this.AppConfig = this.CacheHost.PersistentDataGet<AppConfig>(false, CACHE_FILENAME_APP_CONFIG);
#endif
				if (this.AppConfig == null)
				{
					this.AppConfig = new AppConfig();
				}

                this.CurrentUser = this.CacheHost.CachedUserGet<User>();
                UserResponse userResponse = this.CacheHost.PersistentDataGet<UserResponse>(true, CACHE_FILENAME_USER_RESPONSE);

				if ((this.CurrentUser != null) && (this.CurrentUser.user_id != Guid.Empty))
				{
					this.ViewPlatform.OnLoggedOn();
					this.VerifyCachedUserAsync();					
				}

                if (userResponse == null)
                {
                    this.IsFirstTimeLogin = true;
                }
				else
				{
				    this.IsFirstTimeLogin = false;				    
				}			
            });
        }
        #endregion

        #region Public Properties
        public virtual string ApiBaseUrl { get; protected set; }
        public virtual IViewPlatform ViewPlatform { get; protected set; }
        public virtual AppPreferences AppPreferences { get; protected set; }
		public virtual ICacheHost CacheHost { get; protected set; }
        public virtual IDataCache DataCache { get; protected set; }
        public virtual AppConfig AppConfig { get; protected set; }
        public virtual User CurrentUser { get; protected set; }
        public virtual bool IsFirstTimeLogin { get; protected set; }
        public virtual string TempFolderPath { get; protected set; }
        public virtual string SpeechLocalization { get; protected set; }
        #endregion

        #region Protected properties

        protected virtual SimediaSDK SimediaClientAnonymous { get; set; }
        protected virtual SimediaSDK SimediaClientAuthenticated { get; set; }
        protected string _referralCode;

		protected string DeviceToken
		{
			get
			{
				string result = this.CacheHost.PersistentDataGet<string>(false, "deviceToken");
				if (string.IsNullOrEmpty(result))
				{
					this.CacheHost.PersistentDataSet<string>(false, "deviceToken", Guid.NewGuid().ToString("N"));
					result = this.CacheHost.PersistentDataGet<string>(false, "deviceToken");
				}
				return result;
			}
		}

        #endregion

        #region Public Methods

        public virtual string GetLocalizedText(LanguageToken token, string defaultText)
        {
            return base.ExecuteFunction("GetLocalizedText", delegate ()
            {

                return defaultText;
            });
        }

        public virtual Task<ItemResult<UserResponse>> LoginAsync(string username, string password, Action<bool> onProcessing = null)
        {
            return base.ExecuteFunctionAsync("LoginAsync", async delegate ()
            {
                ItemResult<UserResponse> result = new ItemResult<UserResponse>() { success = false };

				result = await this.PostItemAsync(onProcessing, delegate
			    {
				   SimediaSDK sdk = this.GetSDK();
				   return sdk.Users.GetUserAsync(username, password);
		        });   

                if (result.IsSuccess())
                {
					this.CacheHost.CachedUserSet(result.item);
					this.CurrentUser = result.item;
                    this.UserCacheClear();

                    this.CacheHost.PersistentDataSet(true, CACHE_FILENAME_USER_RESPONSE, result.item);

					AppPreferences prefs = new AppPreferences();
					this.CacheHost.PersistentDataSet(false, CACHE_FILENAME_APP_PREFS, prefs);
					this.AppPreferences = prefs;
                    this.ViewPlatform.OnLoggedOn();
                }
                else
                {
					this.LogOff(false, false);
					if (string.IsNullOrEmpty(result.message))
					{
						result.message = "Could not log in to your account.";
					}
                }

                return result;
            });
        }

        public void ProjectsFetchInvalidateCache()
        {
            base.ExecuteMethod("ProjectsFetchInvalidateCache", delegate ()
            {
                string prefix = "/Projects/";
                this.DataCache.ClearWithPrefix(prefix);
                this.DataCache.InvalidateTimedPrefix(prefix);
            });
        }

        public Task<bool> ProjectsFetchAsync(bool? allowStale, bool force, int page, int page_size, DataFetchedDelegate<ListResult<Project>> onFetched, Action<bool> onFetching = null)
        {
            return base.ExecuteFunctionAsync("ProjectsFetchAsync", async delegate ()
            {
				string cacheKey = string.Format("?page={0}&size={1}", page, page_size);
				string cachePrefix = "/Projects/";
				int staleLimit = force ? 0 : this.AppConfig.Projects_StaleSeconds;
				if (!allowStale.HasValue)
				{
					allowStale = (staleLimit != 0);
				}
				if (force)
				{
					// clear self pages
					this.ProjectsFetchInvalidateCache();
				}
				return await this.FetchListAsync<Project>(allowStale.Value, cachePrefix, cacheKey, staleLimit, onFetched, onFetching, delegate ()
				{
                    SimediaSDK sdk = this.GetSDK();
					return sdk.Projects.GetProjectsAsync(string.Empty, page, page_size, "start_utc", true);
				});
            });
        }

		public void TasksFetchInvalidateCache()
		{
			base.ExecuteMethod("TasksFetchInvalidateCache", delegate ()
			{
				string prefix = "/Tasks/";
				this.DataCache.ClearWithPrefix(prefix);
				this.DataCache.InvalidateTimedPrefix(prefix);
			});
		}

		public Task<bool> TasksFetchAsync(bool? allowStale, bool force, int page, int page_size, DataFetchedDelegate<ListResult<TaskObject>> onFetched, Action<bool> onFetching = null)
		{
			return base.ExecuteFunctionAsync("TasksFetchAsync", async delegate ()
			{
				string cacheKey = string.Format("?page={0}&size={1}", page, page_size);
				string cachePrefix = "/Tasks/";
				int staleLimit = force ? 0 : this.AppConfig.Tasks_StaleSeconds;
				if (!allowStale.HasValue)
				{
					allowStale = (staleLimit != 0);
				}
				if (force)
				{
					// clear self pages
					this.TasksFetchInvalidateCache();
				}
                return await this.FetchListAsync<TaskObject>(allowStale.Value, cachePrefix, cacheKey, staleLimit, onFetched, onFetching, delegate ()
				{
					SimediaSDK sdk = this.GetSDK();
					return sdk.Tasks.GetTasksAsync(string.Empty, page, page_size, "start_utc", true);
				});
			});
		}

		public virtual void LogOff(bool notifyViewPlatform, bool redirect)
		{
			base.ExecuteMethod("LogOff", delegate ()
			{
                this.SimediaClientAnonymous = null;
				this.SimediaClientAuthenticated = null;
				this.ViewPlatform.UnRegisterForPushNotifications();
				this.CacheHost.CachedUserClear();
				this.CacheHost.CachedDataClear();
				this.CacheHost.PersistentDataSet(false, CACHE_FILENAME_APP_PREFS, new AppPreferences());
				this.AppPreferences = new AppPreferences();
				this.UserCacheClear();
				this.DataCache.Clear();
				this.DataCache.InvalidateTimedCache();
				this.CurrentUser = null;
				if (notifyViewPlatform)
				{
					try
					{
						this.ViewPlatform.OnLoggedOff();
					}
					catch (Exception ex)
					{
						this.LogError(ex, "OnLoggedOff");
					}
				}
				if (redirect)
				{
					this.ViewPlatform.NavigateToFirstScreen();
				}
			});
		}

        #endregion

		#region Protected Methods
        protected async virtual Task<T> PostItemAsync<T>(Action<bool> onProcessing, Func<Task<T>> postMethod)
            where T : ActionResult, new()
        {
            try
            {
                if (onProcessing != null)
                {
                    onProcessing(true);
                }
                return await postMethod();
            }
            catch (Exception ex)
            {
                this.ProcessExecuteException(ex, "PostItemAsync");
                throw;
            }
            finally
            {
                if (onProcessing != null)
                {
                    onProcessing(false);
                }
            }
        }

		protected virtual Task<bool> FetchListAsync<T>(bool allowStale, string cachePrefixKey, string cacheSpecificKey, int staleLimit, DataFetchedDelegate<ListResult<T>> onFetched, Action<bool> onFetching, Func<Task<ListResult<T>>> fetchMethod, Action<Exception> onError = null)
		{
			try
			{
				return this.DataCache.WithTimedRefreshForPrefixAsync<ListResult<T>>(allowStale, cachePrefixKey, cacheSpecificKey, staleLimit, onFetched, onFetching, async delegate ()
				{
					return await fetchMethod();
				});
			}
			catch (Exception ex)
			{
				EndpointException endpointException = ex.FirstExceptionOfType<EndpointException>();
				if (endpointException != null)
				{
					switch (endpointException.StatusCode)
					{
						case HttpStatusCode.BadRequest:
						case HttpStatusCode.Unauthorized:
						case HttpStatusCode.Forbidden:
						case HttpStatusCode.NotFound:
						case HttpStatusCode.RequestTimeout:
						case HttpStatusCode.InternalServerError:
						case HttpStatusCode.NotImplemented:
						case HttpStatusCode.ServiceUnavailable:
							this.ViewPlatform.ShowToast("Error connecting to server. Please check connection.");
							break;
						default:
							break;
					}
				}
				if (onError != null)
				{
					onError(ex);
				}
				this.ProcessExecuteException(ex, "FetchListAsync");
				throw;
			}

		}

		protected virtual Task<bool> FetchListAsync<TData, TMeta>(bool allowStale, string cachePrefixKey, string cacheSpecificKey, int staleLimit, DataFetchedDelegate<ListResult<TData, TMeta>> onFetched, Action<bool> onFetching, Func<Task<ListResult<TData, TMeta>>> fetchMethod, Action<Exception> onError = null)
			where TMeta : new()
		{
			try
			{
				return this.DataCache.WithTimedRefreshForPrefixAsync<ListResult<TData, TMeta>>(allowStale, cachePrefixKey, cacheSpecificKey, staleLimit, onFetched, onFetching, async delegate ()
				 {
					 return await fetchMethod();
				 });
			}
			catch (Exception ex)
			{
				EndpointException endpointException = ex.FirstExceptionOfType<EndpointException>();
				if (endpointException != null)
				{
					switch (endpointException.StatusCode)
					{
						case HttpStatusCode.BadRequest:
						case HttpStatusCode.Unauthorized:
						case HttpStatusCode.Forbidden:
						case HttpStatusCode.NotFound:
						case HttpStatusCode.RequestTimeout:
						case HttpStatusCode.InternalServerError:
						case HttpStatusCode.NotImplemented:
						case HttpStatusCode.ServiceUnavailable:
							this.ViewPlatform.ShowToast("Error connecting to server. Please check connection.");
							break;
						default:
							break;
					}
				}
				if (onError != null)
				{
					onError(ex);
				}
				this.ProcessExecuteException(ex, "FetchListAsync");
				throw;
			}

		}

		protected virtual Task VerifyCachedUserAsync()
		{
			return base.ExecuteMethodOrSkipAsync("VerifyCachedUserAsync", async delegate ()
			{
				// do not wrap this in the normal fetch or get data methods, need direct response
				if ((this.CurrentUser != null) && (this.CurrentUser.user_id != Guid.Empty))
				{
					var sdk = this.GetSDK();
					try
					{
                        ItemResult<UserResponse> result = await sdk.Users.GetUserByIdAsync(this.CurrentUser.user_id);
						if (result.IsSuccess() && result.item.user_id == this.CurrentUser.user_id)
						{
							_referralCode = string.Empty;
							this.CurrentUser = result.item;							
						}
					}
					catch (Exception ex)
					{
						if (IsForbidden(ex) || IsUnauthorized(ex))
						{
							//this.LogOff(true, true);
							this.ViewPlatform.DisplayNotification("Session Expired", "Your security session is no longer valid. You have been logged out and must re-authenticate to continue.");
						}
					}
				}
			});
		}

		protected virtual bool IsForbidden(Exception ex)
		{
			AggregateException aggregate = ex as AggregateException;
			if (aggregate != null)
			{
				foreach (var item in aggregate.InnerExceptions)
				{
					if (IsForbidden(item))
					{
						return true;
					}
				}
			}
			EndpointException endpointException = ex as EndpointException;
			if (endpointException != null)
			{
				if (endpointException.StatusCode == System.Net.HttpStatusCode.Forbidden)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual bool IsUnauthorized(Exception ex)
		{
			AggregateException aggregate = ex as AggregateException;
			if (aggregate != null)
			{
				foreach (var item in aggregate.InnerExceptions)
				{
					if (IsUnauthorized(item))
					{
						return true;
					}
				}
			}
			EndpointException endpointException = ex as EndpointException;
			if (endpointException != null)
			{
				if (endpointException.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				{
					return true;
				}
			}
			return false;
		}

        protected virtual void ProcessExecuteException(Exception ex, string methodName)
        {
            base.ExecuteMethod("ProcessEndPointException", delegate ()
            {
                this.LogError(ex, methodName);
            });
        }

        protected virtual SimediaSDK GetSDK(bool useCurrentUserInfo = true)
		{
			SimediaSDK result = null;

            if (useCurrentUserInfo)
            {
                result = this.SimediaClientAuthenticated;
            }
            else
            {
                result = this.SimediaClientAnonymous;
            }

            if (result == null)
            {
				result = new SimediaSDK(this.ApiBaseUrl);

				result.CustomHeaders.Add(new KeyValuePair<string, string>("X-DevicePlatform", this.ViewPlatform.ShortName));
				result.CustomHeaders.Add(new KeyValuePair<string, string>("X-DeviceVersion", this.ViewPlatform.VersionNumber));
				result.CustomHeaders.Add(new KeyValuePair<string, string>("X-DeviceToken", this.DeviceToken));
				result.CustomHeaders.Add(new KeyValuePair<string, string>("X-AppInstance", CoreAssumptions.APP_INSTANCE_NAME));

                if (useCurrentUserInfo)
                {
                    if (this.CurrentUser != null)
                    {
                        result.ApplicationKey = this.CurrentUser.api_key;
                        if (result.ApplicationSecret != this.CurrentUser.api_secret)
                        {
                            result.ApplicationSecret = this.CurrentUser.api_secret;
                        }
                        this.SimediaClientAuthenticated = result;
                    }
                    else
                    {
                        result.ApplicationKey = string.Empty;
                        result.ApplicationSecret = string.Empty;
                        this.SimediaClientAuthenticated = null;
                    }
                }
                else
                {
					result.ApplicationKey = string.Empty;
					result.ApplicationSecret = string.Empty;
                    this.SimediaClientAnonymous = result;
                }				
            }
			
			return result;
		}

		public T UserCacheGet<T>(string token)
			where T : class
		{
			string result = null;
			Dictionary<string, string> userCache = this.CacheHost.PersistentDataGet<Dictionary<string, string>>(false, CACHE_FILENAME_USER_CACHE);
			if (userCache == null)
			{
				userCache = new Dictionary<string, string>();
			}

			if (userCache.TryGetValue(token, out result) && !string.IsNullOrEmpty(result))
			{
				return JsonConvert.DeserializeObject<T>(result);
			}
			else
			{
				return default(T);
			}
		}
		public void UserCacheSet<T>(string token, T value)
			where T : class
		{
			Dictionary<string, string> userCache = this.CacheHost.PersistentDataGet<Dictionary<string, string>>(false, CACHE_FILENAME_USER_CACHE);
			if (userCache == null)
			{
				userCache = new Dictionary<string, string>();
			}
			userCache[token] = JsonConvert.SerializeObject(value);
			this.CacheHost.PersistentDataSet(false, CACHE_FILENAME_USER_CACHE, userCache);
		}
		public void UserCacheClear()
		{
			this.CacheHost.PersistentDataSet(false, CACHE_FILENAME_USER_CACHE, string.Empty);
		}

        #endregion
    }*/
}
