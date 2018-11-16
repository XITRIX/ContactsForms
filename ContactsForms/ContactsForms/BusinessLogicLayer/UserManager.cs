using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using ContactsForms.DataAccessLayer;

namespace ContactsForms.BusinessLogicLayer {
    public class UserManager {
        private readonly DataBase dataBase;

        public ObservableCollection<GroupedUsers> AlphabeticallyGroupedUsers { get; set; }

        public UserManager(Action<Exception> onFinishLoading = null) {
            AlphabeticallyGroupedUsers = new ObservableCollection<GroupedUsers>();
            dataBase = new DataBase((e) => {
                if (e == null)
                    FillAlphabeticallyGroupedUsers();
                onFinishLoading?.Invoke(e);
            });
        }

        public User GetUserAt(int index) {
            return dataBase.users[index];
        }

        public int GetUsersCount() {
            return dataBase.users.Count;
        }

        public List<User> GetUsers() {
            return dataBase.users;
        }

        private void FillAlphabeticallyGroupedUsers() {
            var dict = GetAlphabeticallySortedUsersDictionary();
            var listDataKeys = (new List<char>(dict.Keys));
            listDataKeys.Sort((a, b) => a.CompareTo(b));

            foreach (var key in listDataKeys) {
                var group = new GroupedUsers();
                group.AddRange(dict[key]);
                group.Title = key.ToString();
                AlphabeticallyGroupedUsers.Add(group);
            }
        }

        public Dictionary<char, List<User>> GetAlphabeticallySortedUsersDictionary() {
            Dictionary<char, List<User>> res = new Dictionary<char, List<User>>();

            foreach (var user in dataBase.users) {
                if (!res.ContainsKey(user.Name.UpperLast[0])) {
                    res.Add(user.Name.UpperLast[0], new List<User>());
                }
                res[user.Name.UpperLast[0]].Add(user);
            }

            return res;
        }
    }
}
