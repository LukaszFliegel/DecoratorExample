//using RestSharp;
using RealLifeExample.Decorators;
using RestSharp;
using System;

namespace RealLifeExample
{
    class Program
    {
        private const int _numberOfApiCalls = 10;

        static void Main(string[] args)
        {
            RestCalls();
            //RestCallsWithRetry();
            //RestCallsWithLog();

            Console.ReadKey();
        }

        private static void RestCalls()
        {
            var restClient = new RestClient("https://reqres.in/api");

            for (int i = 0; i < _numberOfApiCalls; i++)
            {
                RestCall(restClient, "users?page=2");
            }
        }

        private static void RestCallsWithRetry()
        {
            var restClient = new RestClientRetryDecorator(new RestClient("https://reqres.in/api"));

            for (int i = 0; i < _numberOfApiCalls; i++)
            {
                RestCall(restClient, "users?page=2");
            }
        }

        private static void RestCallsWithLog()
        {
            var restClient = new RestClientLogDecorator(new RestClient("https://reqres.in/api"));

            for (int i = 0; i < _numberOfApiCalls; i++)
            {
                RestCall(restClient, "users?page=2");
            }
        }

        private static void RestCallsWithCache()
        {
            var restClient = new RestClientCacheDecorator(new RestClient("https://reqres.in/api"));

            for (int i = 0; i < _numberOfApiCalls; i++)
            {
                RestCall(restClient, "users?page=2");
            }
        }

        private static void RestCallsWithRetryAndLog()
        {
            var restClient = new RestClientLogDecorator(new RestClientRetryDecorator(new RestClient("https://reqres.in/api")));

            for (int i = 0; i < _numberOfApiCalls; i++)
            {
                RestCall(restClient, "users?page=2");
            }
        }

        private static void RestCall(IRestClient restClient, string resource)
        {
            var response = restClient.Get(new RestRequest(resource, DataFormat.Json));

            Console.WriteLine($"Response: {response.StatusCode}");
            Console.WriteLine();
        }
    }
}
