// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorMovies.Client.Pages.Movies
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Client.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Shared.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Client.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using BlazorMovies.Shared.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\EditMovie.razor"
           [Authorize(Roles = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/movies/edit/{MovieId:int}")]
    public partial class EditMovie : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\EditMovie.razor"
       
    [Parameter] public int MovieId { get; set; }
    private Movie Movie;
    private List<Genre> NotSelectedGenres;
    private List<Genre> SelectedGenres;
    private List<Person> SelectedActors;

    protected async override Task OnInitializedAsync() {
        var model = await moviesRepository.GetMovieForUpdate(MovieId);
        Movie = model.Movie;
        SelectedActors = model.Actors;
        SelectedGenres = model.SelectedGenres;
        NotSelectedGenres = model.NotSelectedGenres;
    }

    private async Task Edit() {
        await moviesRepository.UpdateMovie(Movie);
        navigationManager.NavigateTo($"movie/{MovieId}/{Movie.Title.Replace(" ", "-")}");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMoviesRepository moviesRepository { get; set; }
    }
}
#pragma warning restore 1591
