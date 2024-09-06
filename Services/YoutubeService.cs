using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeDownloader.Services.Interface;

namespace YoutubeDownloader.Services
{
    public class YoutubeService : IYoutubeService
    {
        private readonly YoutubeClient _youtubeClient;

        public YoutubeService()
        {
            _youtubeClient = new YoutubeClient();
        }

        public async Task BaixarAudioAsync(string videoUrl, string caminhoDestino)
        {
            var video = await _youtubeClient.Videos.GetAsync(videoUrl);

            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Id);

            var audioStreamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var filePath = Path.Combine(caminhoDestino, $"${video.Title}.mp3");

            await DownloadAudioAsync(audioStreamInfo, filePath);
        }
        private async Task DownloadAudioAsync(IStreamInfo streamInfo, string filePath)
        {
            var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfo);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);   
            }
        }
    }
    
}