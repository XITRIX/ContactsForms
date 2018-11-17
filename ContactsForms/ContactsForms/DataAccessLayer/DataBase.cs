using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace ContactsForms.DataAccessLayer {
    public class DataBase {
        private static readonly int count = 1000;
        public List<User> users = new List<User>();

        public DataBase(Action<Exception> onFinishLoading) {
            LoadUsersFromAPIAsync(onFinishLoading);
        }

        private async void LoadUsersFromAPIAsync(Action<Exception> onFinishLoading) {
            try {
                var client = new HttpClient();
                var response = await client.GetStringAsync($"https://randomuser.me/api/?seed=10&results={count}");
                users.AddRange(JsonConvert.DeserializeObject<JSONUsersResult>(response).results);
                users.Sort((a, b) => string.Compare(a.Name.first, b.Name.first, StringComparison.CurrentCulture));
                if (users.Count != count) {
                    throw new ArgumentException($"{nameof(users)} count not match to {count}", nameof(users));
                }
                onFinishLoading.Invoke(null);
            } catch (Exception e) {
                onFinishLoading.Invoke(e);
            }
        }
    }
}
