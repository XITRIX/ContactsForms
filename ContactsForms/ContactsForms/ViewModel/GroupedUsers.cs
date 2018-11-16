using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactsForms {
    public class GroupedUsers : ObservableCollection<User> {
        public string Title { get; set; }

        public void AddRange(ICollection<User> users) {
            foreach (var user in users) {
                Add(user);
            }
        }
    }
}
