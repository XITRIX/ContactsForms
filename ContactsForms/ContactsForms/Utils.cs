using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsForms {
    public static class Utils {
        public static string FirstCharToUpper(this string input) {
            switch (input) {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
