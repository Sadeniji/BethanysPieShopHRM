using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BethanysPieShopHRM.ComponentsLibrary;

public partial class Map
{
    private string elementId = $"map-{Guid.NewGuid():D}";

    [Parameter]
    public double Zoom { get; set; }

    [Parameter]
    public List<Marker> Markers { get; set; }

    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", elementId, Markers);
    }
}