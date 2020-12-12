#pragma checksum "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "905e07137d995fad7bab6855f3cddacca2ffe196"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorMovies.Client.Pages.Genres
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
#line 3 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
           [Authorize(Roles = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/genres")]
    public partial class GenreAll : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Genre List</h3>\n\n");
            __builder.AddMarkupContent(1, "<div class=\"form-group\"><a class=\"btn btn-info\" href=\"genre/create\">New Genre</a></div>\n\n");
            __Blazor.BlazorMovies.Client.Pages.Genres.GenreAll.TypeInference.CreateGenericList_0(__builder, 2, 3, 
#nullable restore
#line 11 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                   Genres

#line default
#line hidden
#nullable disable
            , 4, (__builder2) => {
                __builder2.OpenElement(5, "table");
                __builder2.AddAttribute(6, "class", "table table-striped");
                __builder2.AddMarkupContent(7, "<thead class=\"thead-dark\"><tr><th></th>\n                    <th>Name</th></tr></thead>\n            ");
                __builder2.OpenElement(8, "tbody");
#nullable restore
#line 21 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                 foreach (var genre in Genres) {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(9, "tr");
                __builder2.OpenElement(10, "td");
                __builder2.OpenElement(11, "a");
                __builder2.AddAttribute(12, "class", "btn btn-success");
                __builder2.AddAttribute(13, "href", "/genre/edit/" + (
#nullable restore
#line 24 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                                                                          genre.Id

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(14, "Edit");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\n                            ");
                __builder2.OpenElement(16, "button");
                __builder2.AddAttribute(17, "class", "btn btn-danger");
                __builder2.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                                                                       () => DeleteGenre(genre.Id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(19, "Delete");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(20, "\n                        ");
                __builder2.OpenElement(21, "td");
                __builder2.AddContent(22, 
#nullable restore
#line 27 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                             genre.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 29 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Pages\Genres\GenreAll.razor"
        
    List<Genre> Genres;

    protected override async Task OnInitializedAsync() {
        try {
            Genres = await repoGenre.GetGenres();
        } catch (Exception ex) {
            // Show popup message, log into DB, send email to developer
            Console.WriteLine(ex.Message);
        }
    }

    private async Task DeleteGenre(int Id) {
        try {
            await repoGenre.DeleteGenre(Id);
            Genres = await repoGenre.GetGenres();
        } catch (Exception ex) {
            // Show popup message, log into DB, send email to developer
            Console.WriteLine(ex.Message);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IGenreRepository repoGenre { get; set; }
    }
}
namespace __Blazor.BlazorMovies.Client.Pages.Genres.GenreAll
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateGenericList_0<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.List<TItem> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::BlazorMovies.Client.Shared.GenericList<TItem>>(seq);
        __builder.AddAttribute(__seq0, "List", __arg0);
        __builder.AddAttribute(__seq1, "WholeListTemplate", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591