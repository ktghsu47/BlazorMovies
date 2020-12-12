using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.FileReader;
using BlazorMovies.Client.Auth;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMovies.Client {
	public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

			builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddOptions();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IDisplayMessage, DisplayMessage>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<JwtAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationStateProvider>()
            );
            builder.Services.AddScoped<ILoginService, JwtAuthenticationStateProvider>(
               provider => provider.GetRequiredService<JwtAuthenticationStateProvider>()
            );
            builder.Services.AddScoped<TokenRenewer>();

            await builder.Build().RunAsync();
        }
    }
}