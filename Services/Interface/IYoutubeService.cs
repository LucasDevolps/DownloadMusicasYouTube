using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloader.Services
{
    public interface IYoutubeService{
        Task BaixarAudioAsync(string videoUrl, string caminhoDestino);
    }
}