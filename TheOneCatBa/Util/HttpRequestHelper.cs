using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TheOneCatBa.Utils
{
    public class HttpRequestHelper
    {
        public Dictionary<string, string> Header { get; set; }
        public Dictionary<string, object> Parameter { get; set; }
        public bool AlwaysMultipartFormData { get; set; } = false;

        public HttpRequestHelper()
        {
            Header = new Dictionary<string, string>();
            Parameter = new Dictionary<string, object>();
        }

        public IRestResponse Get(string url, int timeout = -1)
        {
            var client = new RestClient(url)
            {
                Timeout = timeout
            };
            var request = new RestRequest(Method.GET)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            Header.Keys.ToList().ForEach(key =>
            {
                request.AddHeader(key, Header[key]);
            });

            Parameter.Keys.ToList().ForEach(key =>
            {
                request.AddParameter(key, Parameter[key]);
            });

            ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Post(string url, string jsonData, int timeout = -1)
        {
            var client = new RestClient(url)
            {
                Timeout = timeout
            };
            var request = new RestRequest(Method.POST)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            Header.Keys.ToList().ForEach(key =>
            {
                request.AddHeader(key, Header[key]);
            });
            if (!string.IsNullOrWhiteSpace(jsonData))
                request.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            Parameter.Keys.ToList().ForEach(key =>
            {
                request.AddParameter(key, Parameter[key]);
            });


            ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Post<T>(string url, T entity, int timeout = -1)
        {
            string requestEntity = JsonConvert.SerializeObject(entity, Formatting.None,
                 new JsonSerializerSettings
                 {
                     NullValueHandling = NullValueHandling.Ignore,
                 });
            return Post(url, requestEntity, timeout);
        }

        public IRestResponse Post(string url, Dictionary<string, string> prms, Dictionary<string, byte[]> files = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            List<string> prmKeys = prms.Keys.ToList();
            prmKeys.ForEach(key =>
            {
                request.AddParameter(key, prms[key]);
            });

            if (files != null)
            {
                List<string> fileKeys = files.Keys.ToList();
                fileKeys.ForEach(key =>
                {
                    request.AddFile("FileContent", files[key], key);
                });
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Put(string url, string jsonData, int timeout = -1)
        {
            var client = new RestClient(url)
            {
                Timeout = timeout
            };
            var request = new RestRequest(Method.PUT)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            Header.Keys.ToList().ForEach(key =>
            {
                request.AddHeader(key, Header[key]);
            });
            if (!string.IsNullOrWhiteSpace(jsonData))
                request.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            Parameter.Keys.ToList().ForEach(key =>
            {
                request.AddParameter(key, Parameter[key]);
            });
            ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Put<T>(string url, T entity, int timeout = -1)
        {
            string requestEntity = JsonConvert.SerializeObject(entity, Formatting.None,
                 new JsonSerializerSettings
                 {
                     NullValueHandling = NullValueHandling.Ignore,
                 });
            return Put(url, requestEntity, timeout);
        }

        public IRestResponse Put(string url, Dictionary<string, string> prms, Dictionary<string, byte[]> files = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            List<string> prmKeys = prms.Keys.ToList();
            prmKeys.ForEach(key =>
            {
                request.AddParameter(key, prms[key]);
            });

            if (files != null)
            {
                List<string> fileKeys = files.Keys.ToList();
                fileKeys.ForEach(key =>
                {
                    request.AddFile("FileContent", files[key], key);
                });
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Delete(string url, string body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE)
            {
                AlwaysMultipartFormData = AlwaysMultipartFormData
            };

            Header.Keys.ToList().ForEach(key =>
            {
                request.AddHeader(key, Header[key]);
            });

            if (!string.IsNullOrWhiteSpace(body))
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            IRestResponse response = client.Execute(request);
            return response;
        }

    }
}
