﻿using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorMovies.Client.Helpers {
	public static class JsRuntimeExtensions {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class {
            await js.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }

        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message) {
            await js.InvokeVoidAsync("console.log", "example message");

            return await js.InvokeAsync<bool>("confirm", message);
        }

        public static async ValueTask MyFunction(this IJSRuntime js, string message) {
            await js.InvokeVoidAsync("my_function", message);
        }

        public static ValueTask<object> SetLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        public static ValueTask<string> GetLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        public static ValueTask<object> RemoveLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);
    }
}