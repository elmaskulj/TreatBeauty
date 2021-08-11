using Flurl.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.WinUI.Properties;
using TreatBeauty.Model;

namespace TreatBeauty.WinUI
{
    public class ApiService
    {
        private string _resource = null;
        public string _endpoint = $"{Resources.ApiURL}";

        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static ICollection<BaseUserRole> UserRoles { get; set; }

        public ApiService(string _resource)
        {
            this._resource = _resource;
        }
        public async Task<T> GetAll<T>(object request = null)
        {
            var query = "";
            if (request != null)
            {
                query = await request?.ToQueryString();
            }
            var result = await $"{_endpoint}{_resource}?{query}"
               .WithBasicAuth(UserName, Password).GetJsonAsync<T>();


            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_endpoint}{_resource}/{id}";
            var result = await url.WithBasicAuth(UserName, Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<bool> Delete<T>(object id)
        {
            var url = $"{_endpoint}{_resource}/{id}";
            var result = await url.WithBasicAuth(UserName, Password).DeleteAsync().ReceiveJson<bool>();
            return result;
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_endpoint}{_resource}";

            try
            {
                return await url.WithBasicAuth(UserName, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_endpoint}{_resource}/{id}";

                return await url.WithBasicAuth(UserName, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
    }
}
