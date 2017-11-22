using System;
namespace Simedia.App.SDK.Endpoints
{
    public abstract class EndpointBase
    {
        protected virtual SimediaSDK Sdk { get; set; }

        public EndpointBase(SimediaSDK sdk)
        {
            this.Sdk = sdk;
        }
    }
}
