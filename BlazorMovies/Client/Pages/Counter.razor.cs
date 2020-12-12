﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorMovies.Client.Pages {
	public partial class Counter {
        private int currentCount = 0;

        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task IncrementCount() {
            var authState = await AuthenticationState;
            var user = authState.User;

            if (user.Identity.IsAuthenticated) {
                currentCount++;
            } else {
                currentCount--;
            }
        }
    }
}