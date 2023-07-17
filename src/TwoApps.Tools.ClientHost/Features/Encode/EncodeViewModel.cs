using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using TwoApps.Tools.ClientHost.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TwoApps.Tools.ClientHost.Features;

public partial class EncodeViewModel : ObservableObject
{
    private ClipboardService _clipboardService;

    public EncodeViewModel(ClipboardService clipboardService)
    {
        _clipboardService = clipboardService;
    }

    [ObservableProperty]
    private string _source;

    [ObservableProperty]
    private string _target;

    public async void Base64Encode()
    {
        try
        {
            var result = Encoding.UTF8.GetBytes(Source);
            Target = Convert.ToBase64String(result);
            await CopyToClipboardAsync();
        }
        catch
        {
            Target = "Error";
        }
    }

    public async void Base64Decode()
    {
        try
        {
            byte[] result = Convert.FromBase64String(Source);
            Target = Encoding.UTF8.GetString(result);
            await CopyToClipboardAsync();
        }
        catch
        {
            Target = "Error";
        }
    }

    private async Task CopyToClipboardAsync()
    {
        try
        {
            await _clipboardService.WriteTextAsync(Target);
        }
        catch
        {
            // failed but don't do anything about it
        }
    }
}
