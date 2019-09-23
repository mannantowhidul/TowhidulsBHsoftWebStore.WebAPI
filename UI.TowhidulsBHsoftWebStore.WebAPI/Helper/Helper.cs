using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI.TowhidulsBHsoftWebStore.WebAPI.Helper
{
    public class AdminAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }

    public class CompanyAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }

    public class BuyerAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }

    public class SupplierAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }

    public class BuyerRequestSubmissionAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }

    public class SupplierProcessNpracticeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373/");
            return client;
        }
    }
}
