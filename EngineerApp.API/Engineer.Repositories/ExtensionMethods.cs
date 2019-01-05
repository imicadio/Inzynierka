﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engineer.Repositories
{
    public static class ExtensionMethods
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
