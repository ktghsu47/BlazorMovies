#pragma checksum "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb2a9253661cd88b87feb4c459db2a5d0d5e1c5e"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorMovies.Client.Shared
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
#line 2 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
    public partial class CustomTypeahead<TItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "blazored-typeahead");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "blazored-typeahead__controls");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "type", "text");
            __builder.AddAttribute(6, "class", "blazored-typeahead__input");
            __builder.AddAttribute(7, "autocomplete", "off");
            __builder.AddAttribute(8, "placeholder", 
#nullable restore
#line 7 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                                                                              Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(9, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                                                             ShowSuggestions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onfocusout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 8 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                                                                                           onfocusout

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 8 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                          SearchText

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SearchText = __value, SearchText));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 10 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
     if (isSearching) {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(13, "<div class=\"blazored-typeahead__results\"><div class=\"blazored-typeahead__result\"><span>Loading...</span></div></div>");
#nullable restore
#line 16 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
    } else if (ShouldShowSuggestions()) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "blazored-typeahead__results");
#nullable restore
#line 18 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
             foreach (var item in Suggestions) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "blazored-typeahead__result");
            __builder.AddAttribute(18, "tabindex", "0");
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                 () => SelectSuggestion(item)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(20, "onmouseover", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                                                              OnmouseoverSuggestion

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "onmouseout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                                                                                                                  OnmouseoutSuggestion

#line default
#line hidden
#nullable disable
            ));
            __builder.SetKey(
#nullable restore
#line 19 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                           item

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(22, 
#nullable restore
#line 21 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                     ResultTemplate(item)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 23 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 25 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
    } else if (ShowNotFound()) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "blazored-typeahead__results");
#nullable restore
#line 27 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
             if (NotFoundTemplate != null) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "blazored-typeahead__notfound");
            __builder.AddContent(27, 
#nullable restore
#line 29 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
                     NotFoundTemplate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 31 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
            } else {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(28, "<div class=\"blazored-typeahead__notfound\">\n                    No Results Found\n                </div>");
#nullable restore
#line 35 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 37 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\My Documents\AppCodes\BlazorMovies\BlazorMovies\Client\Shared\CustomTypeahead.razor"
       
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public int MinimumLength { get; set; } = 3;
    [Parameter] public int Debounce { get; set; } = 300;
    [Parameter] public Func<string, Task<IEnumerable<TItem>>> SearchMethod { get; set; }
    [Parameter] public RenderFragment<TItem> ResultTemplate { get; set; }
    [Parameter] public RenderFragment NotFoundTemplate { get; set; }
    [Parameter] public EventCallback<TItem> ValueChanged { get; set; }

    private bool isSearching = false;
    private bool isShowingSuggestions = false;
    private string _searchText = string.Empty;
    private Timer _debounceTimer;
    protected TItem[] Suggestions { get; set; } = new TItem[0];

    protected override void OnInitialized() {
        _debounceTimer = new Timer();
        _debounceTimer.Interval = Debounce;
        _debounceTimer.AutoReset = false;
        _debounceTimer.Elapsed += Search;

        base.OnInitialized();
    }

    private bool ShowNotFound() {
        return !Suggestions.Any() && isShowingSuggestions;
    }

    private async Task SelectSuggestion(TItem item) {
        SearchText = "";
        await ValueChanged.InvokeAsync(item);
    }

    protected async void Search(Object source, ElapsedEventArgs e) {
        isSearching = true;
        isShowingSuggestions = false;
        await InvokeAsync(StateHasChanged);

        Suggestions = (await SearchMethod.Invoke(_searchText)).ToArray();

        isSearching = false;
        isShowingSuggestions = true;
        await InvokeAsync(StateHasChanged);
    }

    private string SearchText {
        get => _searchText;
        set {
            _searchText = value;

            if (value.Length == 0) {
                isShowingSuggestions = false;
                _debounceTimer.Stop();
                Suggestions = new TItem[0];
            } else if (value.Length >= MinimumLength) {
                _debounceTimer.Stop();
                _debounceTimer.Start();
            }
        }
    }

    private bool ShouldShowSuggestions() {
        return isShowingSuggestions && Suggestions.Any();
    }

    private void ShowSuggestions() {
        if (Suggestions.Any()) {
            isShowingSuggestions = true;
        }
    }

    private void onfocusout() {
        if (!IsMouseInSuggestion) {
            isShowingSuggestions = false;
        }
    }

    bool IsMouseInSuggestion = false;

    private void OnmouseoverSuggestion() {
        IsMouseInSuggestion = true;
    }

    private void OnmouseoutSuggestion() {
        IsMouseInSuggestion = false;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591