#pragma checksum "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a50429303972a573d97476f2cccade77888501c"
// <auto-generated/>
#pragma warning disable 1591
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
#nullable restore
#line 7 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
 if (detailsMovieDTO == null) {
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "Loading...");
#nullable restore
#line 8 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                           
} else {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "h2");
            __builder.AddContent(2, 
#nullable restore
#line 10 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
         detailsMovieDTO.Movie.Title

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(3, " (");
            __builder.AddContent(4, 
#nullable restore
#line 10 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                       detailsMovieDTO.Movie.ReleaseDate.Value.ToString("yyyy")

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(5, ")");
            __builder.CloseElement();
#nullable restore
#line 11 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
    for (int i = 0; i < detailsMovieDTO.Genres.Count; i++) {
        if (i < detailsMovieDTO.Genres.Count - 1) {
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, 
#nullable restore
#line 13 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
             linkGenre(detailsMovieDTO.Genres[i])

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(7, ", ");
#nullable restore
#line 13 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                
        } else {
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, 
#nullable restore
#line 15 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
             linkGenre(detailsMovieDTO.Genres[i])

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 15 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                 
        }
    }
    

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, " |  ");
            __builder.OpenElement(10, "span");
            __builder.AddContent(11, 
#nullable restore
#line 18 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                            detailsMovieDTO.Movie.ReleaseDate.Value.ToString("dd MMM yyyy")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddContent(12, " | Average: ");
            __builder.AddContent(13, 
#nullable restore
#line 19 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                               detailsMovieDTO.AverageVote.ToString("0.#")

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(14, "/5 | Your vote: \n    ");
            __builder.OpenComponent<BlazorMovies.Client.Shared.Rating>(15);
            __builder.AddAttribute(16, "MaximumRating", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                           5

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "SelectedRating", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                              detailsMovieDTO.UserVote

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "OnVote", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                OnVote

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "style", "display: flex");
            __builder.OpenElement(21, "span");
            __builder.AddAttribute(22, "style", "display: inline-block; margin-right: 5px;");
            __builder.OpenElement(23, "img");
            __builder.AddAttribute(24, "src", 
#nullable restore
#line 23 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                           detailsMovieDTO.Movie.Poster

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(25, "style", "width: 225px; height: 315px");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\n        ");
            __builder.OpenElement(27, "iframe");
            __builder.AddAttribute(28, "width", "560");
            __builder.AddAttribute(29, "height", "315");
            __builder.AddAttribute(30, "src", "https://www.youtube.com/embed/" + (
#nullable restore
#line 24 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                             detailsMovieDTO.Movie.Trailer

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "frameborder", "0");
            __builder.AddAttribute(32, "allow", "accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture");
            __builder.AddAttribute(33, "allowfullscreen", true);
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\n    ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "style", "margin-top: 10px;");
            __builder.AddMarkupContent(37, "<h3>Summary</h3>\n        ");
            __builder.OpenElement(38, "div");
            __builder.OpenComponent<BlazorMovies.Client.Shared.RenderMarkdown>(39);
            __builder.AddAttribute(40, "MarkdownContent", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 29 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                              detailsMovieDTO.Movie.Summary

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\n    ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "style", "margin-top: 10px;");
            __builder.AddMarkupContent(44, "<h3>Actors</h3>\n        ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "style", "display: flex; flex-direction: column");
#nullable restore
#line 35 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
             foreach (var actor in detailsMovieDTO.Actors) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(47, "div");
            __builder.AddAttribute(48, "style", "margin-bottom: 2px;");
            __builder.OpenElement(49, "img");
            __builder.AddAttribute(50, "style", "width: 50px;");
            __builder.AddAttribute(51, "src", 
#nullable restore
#line 37 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                    actor.Picture

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\n                    ");
            __builder.OpenElement(53, "span");
            __builder.AddAttribute(54, "style", "display:inline-block;width: 200px;");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(55);
            __builder.AddAttribute(56, "Roles", "Admin");
            __builder.AddAttribute(57, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(58, "a");
                __builder2.AddAttribute(59, "href", "/person/edit/" + (
#nullable restore
#line 41 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                       actor.Id

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(60, 
#nullable restore
#line 41 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                  actor.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(61, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddContent(62, 
#nullable restore
#line 44 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                 actor.Name

#line default
#line hidden
#nullable disable
                );
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\n                    ");
            __builder.AddMarkupContent(64, "<span style=\"display:inline-block; width: 45px;\">...</span>\n                    ");
            __builder.OpenElement(65, "span");
            __builder.AddContent(66, 
#nullable restore
#line 49 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                           actor.Character

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 51 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 54 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
       
    [Parameter] public int MovieId { get; set; }
    [Parameter] public string MovieName { get; set; }
    private RenderFragment<Genre> linkGenre = (genre) =>

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.OpenElement(67, "a");
            __builder2.AddAttribute(68, "href", "movies/search?genreId=" + (
#nullable restore
#line 59 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                         genre.Id

#line default
#line hidden
#nullable disable
            ));
            __builder2.AddContent(69, 
#nullable restore
#line 59 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                                      genre.Name

#line default
#line hidden
#nullable disable
            );
            __builder2.CloseElement();
        }
#nullable restore
#line 59 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Movies\DetailsMovie.razor"
                                                                                                                     ;
    DetailsMovieDTO detailsMovieDTO;

    protected async override Task OnInitializedAsync() {
        detailsMovieDTO = await repoMovie.GetDetailsMovieDTO(MovieId);
    }

    private async Task OnVote(int selectedRate) {
        detailsMovieDTO.UserVote = selectedRate;
        var movieRating = new MovieRating() { Rate = selectedRate, MovieId = MovieId };
        await repoRating.Vote(movieRating);
        await msg.DisplaySuccessMessage("Your vote have been received!");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDisplayMessage msg { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRatingRepository repoRating { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMovieRepository repoMovie { get; set; }
    }
}
#pragma warning restore 1591
