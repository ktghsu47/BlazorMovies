using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace BlazorMovies.Client.Helpers {
	public static class NavigationManagerExtensions {
        public static Dictionary<string, string> GetQueryStrings(this NavigationManager nav, string url) {
            if (string.IsNullOrWhiteSpace(url) || !url.Contains("?") || url.Substring(url.Length - 1) == "?") {
                return null;
            }

            var queryStrings = url.Split(new string[] { "?" }, StringSplitOptions.None)[1];

            return queryStrings.Split('&').ToDictionary(
                c => c.Split('=')[0],
                c => Uri.UnescapeDataString(c.Split('=')[1])
            );
        }
    }
}