using RestSharp;
using System;
using System.Collections.Generic;

namespace RealLifeExample.Decorators
{
    public class RestClientCacheDecorator : IRestClient
    {
        private readonly IRestClient _decoratedRestClient;
        private Dictionary<string, IRestResponse> _cache = new Dictionary<string, IRestResponse>();

        public RestClientCacheDecorator(IRestClient restClient)
        {
            _decoratedRestClient = restClient;
        }

        public IRestResponse Get(RestRequest request)
        {
            if (_cache.ContainsKey(request.Resource))
            {
                Console.WriteLine($"Response for a {request.Resource} found in cache");
                return _cache[request.Resource];
            }

            IRestResponse restResponse;

            restResponse = _decoratedRestClient.Get(request);

            if (restResponse.IsSuccessful)
            {
                _cache.Add(request.Resource, restResponse);
            }

            return restResponse;
        }
    }
}
