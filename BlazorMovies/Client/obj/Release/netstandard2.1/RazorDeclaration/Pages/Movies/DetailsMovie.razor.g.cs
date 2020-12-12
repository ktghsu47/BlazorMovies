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
    [Microsoft.AspNetCore.Components.RouteAttribute("/movie/{MovieId:int}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/movie/{MovieId:int}/{MovieName}")]
    public partial class DetailsMovie : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
       
    [Parameter] public int MovieId { get; set; }
    [Parameter] public string MovieName { get; set; }
    private RenderFragment<Genre> linkGenre = (genre) =>

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.OpenElement(0, "a");
            __builder2.AddAttribute(1, "href", "movies/search?genreId=" + (
#nullable restore
#line 50 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                         genre.Id

#line default
#line hidden
#nullable disable
            ));
            __builder2.AddContent(2, " ");
            __builder2.AddContent(3, 
#nullable restore
#line 50 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                                      genre.Name

#line default
#line hidden
#nullable disable
            );
            __builder2.AddContent(4, " ");
            __builder2.CloseElement();
        }
#nullable restore
#line 50 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                                                     ;
    DetailsMovieDTO model;

    protected async override Task OnInitializedAsync() {
        model = await moviesRepository.GetDetailsMovieDTO(MovieId);
    }

    private async Task OnVote(int selectedRate) {
        model.UserVote = selectedRate;
        var movieRating = new MovieRating() { Rate = selectedRate, MovieId = MovieId };
        await ratingRepository.Vote(movieRating);
        await displayMessage.DisplaySuccessMessage("Your vote have been received!");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDisplayMessage displayMessage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRatingRepository ratingRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMoviesRepository moviesRepository { get; set; }
    }
}
#pragma warning restore 1591
