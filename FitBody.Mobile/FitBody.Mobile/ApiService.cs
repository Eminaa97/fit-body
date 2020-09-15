using System.Text;
using System.Threading.Tasks;
using FitBody.Common.Extensions;
using Flurl.Http;

namespace FitBody.Mobile
{
    public class ApiService
    {
        /// <summary>
        /// Full route to the resource (controller/action/etc)
        /// </summary>
        public string Route { get; }
        public static string ApiUrl = "http://localhost:58744/api";
        public static string Url = "http://localhost:58744";

        public static string Token { get; set; }
        public static int LoggedInUserId { get; set; } = -1;
        public static int Permission { get; set; } = -1;

        /// <summary>
        /// Creates a new instance of FitBody.Mobile.ApiService
        /// </summary>
        /// <param name="route">Controller route</param>
        public ApiService(string route)
        {
            Route = route;
        }

        public async Task<T> Get<T>(object searchRequest = null, string action = null)
        {
            var query = string.Empty;
            if (searchRequest != null)
            {
                query = await searchRequest?.ToQueryString();
            }

            string url = $"{ApiUrl}/{Route}";

            if (!string.IsNullOrEmpty(action))
            {
                url += $"/{action}";
            }

            var list = await $"{url}?{query}"
                .WithHeader("Accept", "application/json")
                .WithOAuthBearerToken(Token)
                .GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{ApiUrl}/{Route}/{id}";

            return await url
                .WithHeader("Accept", "application/json")
                .WithOAuthBearerToken(Token)
                .GetJsonAsync<T>();
        }

        public async Task<T> Post<T>(object data = null, string action = null)
        {
            var url = $"{ApiUrl}/{Route}";

            if (!string.IsNullOrEmpty(action))
            {
                url += $"/{action}";
            }

            try
            {
                return await url
                    .WithHeader("Accept", "application/json")
                    .WithOAuthBearerToken(Token)
                    .PostJsonAsync(data)
                    .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (action != "login")
                {
                    var stringBuilder = new StringBuilder(ex.Message);

                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                }
                return default;
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{ApiUrl}/{Route}/{id}";

                return await url
                    .WithHeader("Accept", "application/json")
                    .WithOAuthBearerToken(Token)
                    .PutJsonAsync(request)
                    .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var stringBuilder = new StringBuilder(ex.Message);

                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<T> Delete<T>(int id)
        {
            try
            {
                var url = $"{ApiUrl}/{Route}/{id}";

                return await url
                    .WithHeader("Accept", "application/json")
                    .WithOAuthBearerToken(Token)
                    .DeleteAsync()
                    .ReceiveJson<T>();
            }
            catch (System.Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return default;
            }
        }
    }
}

