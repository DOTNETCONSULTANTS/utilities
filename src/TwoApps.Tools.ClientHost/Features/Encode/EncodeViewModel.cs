using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TwoApps.Tools.ClientHost.Features;

public partial class EncodeViewModel : ObservableObject
{
    [ObservableProperty]
    private string _source;

    [ObservableProperty]
    private string _target;

    public void Base64Encode()
    {
        try
        {
            var result = Encoding.UTF8.GetBytes(Source);
            Target = Convert.ToBase64String(result);
        }
        catch
        {
            Target = "Error";
        }
    }

    public void Base64Decode()
    {
        try
        {
            byte[] result = Convert.FromBase64String(Source);
            Target = Encoding.UTF8.GetString(result);
        }
        catch
        {
            Target = "Error";
        }
    }
}
