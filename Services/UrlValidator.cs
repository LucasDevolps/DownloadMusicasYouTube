using YoutubeDownloader.Services.Interface;

namespace YoutubeDownloader.Services
{
    public class Urlvalidator : IUrlValidator
    {
        public bool IsValidUrl(string url){
            return Uri.TryCreate(url,UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}