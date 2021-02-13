using AppWeb.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AppWeb.Util;
using AppWeb.Servicos.Interface.Notificador;

namespace AppWeb.Servicos.Client.Base
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _acessor;
        private readonly INotificador _notificador;
        private readonly IOptions<ApplicationSettings> _appSettings;
        private Uri BaseEndpoint;
        private string _token;

        public ApiClient(IOptions<ApplicationSettings> appSettings, IHttpContextAccessor acessor,
            INotificador notificador)
        {
            _appSettings = appSettings;
            if (appSettings == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = new Uri(appSettings.Value.WebApiUrl);
            _httpClient = new HttpClient();
            _acessor = acessor;
            _notificador = notificador;

        }

        public async Task<Message<T>> GetAsync<T>(Uri requestUrl)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }


        public async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {
            addHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            addHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T1>>(data);
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public async Task<Message<T>> PutAsync<T>(Uri requestUrl, T content)
        {
            addHeaders();
            var response = await _httpClient.PutAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public async Task<Message<T1>> PutAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            addHeaders();
            var response = await _httpClient.PutAsync(requestUrl.ToString(), CreateHttpContent(content));
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T1>>(data);
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        public async Task<bool> DeteleAsync<T>(Uri requestUrl)
        {
            addHeaders();
            var response = await _httpClient.DeleteAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<T>(data);
                return true;
            }
            else
            {
                _acessor.HttpContext.Response.StatusCode = (int)response.StatusCode;
                throw new HttpResponseException(response.StatusCode, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        public Uri CreateRequestUri(string relativePath, NameValueCollection query = null)
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            if (query != null)
            {
                var collection = HttpUtility.ParseQueryString(string.Empty);

                foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
                {
                    collection[key] = query[key];
                }
                uriBuilder.Query = collection.ToString();
            }

            return uriBuilder.Uri;
        }

        public HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        public void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
        }

        public NameValueCollection GetNameValueCollection<TFiltroDTO>(TFiltroDTO filtro, bool considerarArray = true)
        {
            var queryCollection = new NameValueCollection();

            foreach (var propertyInfo in filtro.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(filtro, null);

                if (value != null)
                {
                    if (propertyInfo.PropertyType == typeof(DateTime) | propertyInfo.PropertyType == typeof(Nullable<DateTime>))
                        value = GerarValorPorDatetime((DateTime)value);
                    if (propertyInfo.PropertyType == typeof(decimal) || propertyInfo.PropertyType == typeof(Nullable<decimal>))
                        value = GerarValorPorDecimal((decimal)value);
                    if (considerarArray)
                    {
                        if (propertyInfo.PropertyType == typeof(string[]))
                            foreach (var sValue in (string[])value)
                                queryCollection.Add(propertyInfo.Name, sValue.ToString());
                        else
                            queryCollection.Add(propertyInfo.Name, value.ToString());
                    }
                    else
                    {
                        if (propertyInfo.PropertyType == typeof(string[]))
                            continue;
                        else
                            queryCollection.Add(propertyInfo.Name, value.ToString());
                    }
                }
            }

            
            return queryCollection;
        }

        private string GerarValorPorDatetime(DateTime dateValue)
        {
            var value = string.Empty;
            if (dateValue != DateTime.MinValue && dateValue != null)
                value = dateValue.ToString("MM/dd/yyyy HH:mm:ss");

            return value;
        }

        private string GerarValorPorDecimal(decimal decimalValue)
        {
            return decimalValue.ToString(ConfiguracaoRegional.SQL());
        }

    }
}
