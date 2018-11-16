using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace ContactsForms {
    public class JSONUsersResult {
        public List<User> results;
    }

    public class User {
        public string Gender { get; set; }
        public UserName Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Picture Picture { get; set; }

        public string GetFullName(bool withTitle = false) {
            return withTitle
                ? $"{Name.UpperTitle} {Name.UpperFirst} {Name.UpperLast}"
                    : $"{Name.UpperFirst} {Name.UpperLast}";
        }

        public string FullName {
            get {
                return $"{Name.UpperFirst} {Name.UpperLast}";
            }
        }

        public string FullTitledName {
            get {
                return $"{Name.UpperTitle} {Name.UpperFirst} {Name.UpperLast}";
            }
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(this);
        }

        public static User Deserialize(string serializedString) {
            return JsonConvert.DeserializeObject<User>(serializedString);
        }
    }

    public class UserName {
        public string title;
        public string first;
        public string last;

        public string UpperTitle {
            get {
                return title.FirstCharToUpper();
            }
        }

        public string UpperFirst {
            get {
                return first.FirstCharToUpper();
            }
        }

        public string UpperLast {
            get {
                return last.FirstCharToUpper();
            }
        }
    }

    public class Location {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
    }

    public class Picture {
        public string large;
        public string medium;
        public string thumbnail;

        public Uri GetImageUri {
            get {
                return new Uri(large);
            }
        }
    }
}
