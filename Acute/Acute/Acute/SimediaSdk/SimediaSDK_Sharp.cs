using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace Simedia.App.SDK
{
    public partial class SimediaSDK
    {
        #region Public Methods

        public Task<IRestResponse> Execute(RestRequest request)
		{
			RestClient client = new RestClient();
            
			//this.PrepareRequest(client, request);

            Task<IRestResponse> response = client.Execute(request);
			//this.ValidateResponse(response);


			return response;
		}



		//public T Execute<T>(RestRequest request)
		//	where T : new()
		//{
		//	RestClient client = new RestClient();

		//	this.PrepareRequest(client, request);

  //          Task < IRestResponse < T>> response = client.Execute<T>(request);
		//	//this.ValidateResponse(response);

		//	return response.Result;
		//}

		public async Task<IRestResponse> ExecuteAsync(RestRequest request)
		{
			return await ExecuteAsync(request, this.AsyncTimeoutMillisecond);
		}
		public async Task<IRestResponse> ExecuteAsync(RestRequest request, int milliSecondTimeout)
		{
			return await Task.Factory.StartNew(() =>
			{
				if (milliSecondTimeout <= 0)
				{
					milliSecondTimeout = this.AsyncTimeoutMillisecond;
				}
				Task<IRestResponse> task = ExecuteAsyncInternal(request);
				bool completed = task.Wait(milliSecondTimeout);
				if (completed)
				{
					return task.Result;
				}
				throw new Exception();
			});
		}

		public async Task<T> ExecuteAsync<T>(RestRequest request)
			where T : new()
		{
			return await ExecuteAsync<T>(request, this.AsyncTimeoutMillisecond);
		}
		public async Task<T> ExecuteAsync<T>(RestRequest request, int milliSecondTimeout)
			where T : new()
		{
			return await Task.Factory.StartNew(() =>
			{
				if (milliSecondTimeout <= 0)
				{
					milliSecondTimeout = this.AsyncTimeoutMillisecond;
				}
				Task<T> task = ExecuteAsyncInternal<T>(request);
				bool completed = task.Wait(milliSecondTimeout);
				if (completed)
				{
					return task.Result;
				}
				throw new Exception();
			});
		}

		#endregion

		#region Protected Methods

		//protected virtual void PrepareRequest(RestClient client, RestRequest request)
		//{
		//	client.BaseUrl = new Uri(BaseUrl);
		//	request.RequestFormat = DataFormat.Json;
		//	request.JsonSerializer = new NewtonSoftSerializer();
		//	this.AddAuthorizationHeaders(client, request);
		//	this.AddCustomHeaders(client, request);
		//}
		protected virtual async Task<IRestResponse> ExecuteAsyncInternal(RestRequest request)
		{
			RestClient client = new RestClient();

			//this.PrepareRequest(client, request);

			IRestResponse response = await client.Execute(request);

			//this.ValidateResponse(response);

			return response;
		}
		protected virtual async Task<T> ExecuteAsyncInternal<T>(RestRequest request)
			where T : new()
		{
			RestClient client = new RestClient();

			//this.PrepareRequest(client, request);

            IRestResponse response = await client.Execute(request);

			//this.ValidateResponse(response);

			return JsonConvert.DeserializeObject<T>(response.Content);
		}


		//protected virtual void AddCustomHeaders(RestClient client, RestRequest request)
		//{
		//	if (this.CustomHeaders != null)
		//	{
		//		foreach (var item in this.CustomHeaders)
		//		{
		//			if (!string.IsNullOrEmpty(item.Key))
		//			{
		//				client.AddDefaultHeader(item.Key, item.Value);
		//			}
		//		}
		//	}
		//}
		//protected virtual void AddAuthorizationHeaders(RestClient client, RestRequest request)
		//{
		//	if (!string.IsNullOrEmpty(this.ApplicationKey) && !string.IsNullOrEmpty(this.ApplicationSecret))
		//	{
		//		client.AddDefaultHeader(API_PARAM_KEY, this.ApplicationKey);
		//		client.AddDefaultHeader(API_PARAM_SIG, this.SignatureGenerator.CreateSignature(this.ApplicationKey, this.ApplicationSecret));
		//	}
		//}
		//protected virtual void ValidateResponse(Task<IRestResponse> response)
		//{
		//	switch (response.Status)
		//	{

		//		case System.Net.HttpStatusCode.Continue:
		//		case System.Net.HttpStatusCode.Accepted:
		//		case System.Net.HttpStatusCode.Created:
		//		case System.Net.HttpStatusCode.NoContent:
		//		case System.Net.HttpStatusCode.NotModified:
		//		case System.Net.HttpStatusCode.OK:
		//			// do nothing
		//			break;
		//		default:
		//			throw new EndpointException(response.StatusCode, response.StatusDescription);
		//	}

		//	//if (response.ErrorException != null)
		//	//{
		//	//	throw new ApplicationException("Error retrieving response.  Check inner details for more info.", response.ErrorException);
		//	//}
		//}

		#endregion
	}
}
