using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using OpenSilver.WebAssembly;
using System.Threading.Tasks;

namespace XRSharpSamplesGallery.Browser.Pages;

[Route("/")]
public class Index : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
    }

    protected override async Task OnInitializedAsync()
    {
        await Runner.RunApplicationAsync(async () =>
        {
            await XRSharp.Root3D.Initialize();
            return new XRSharpSamplesGallery.App();
        });
    }
}