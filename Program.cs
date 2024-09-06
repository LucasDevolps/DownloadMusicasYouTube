using YoutubeDownloader.Services;
using YoutubeDownloader.Services.Interface;
using System;

public class Program{
    private static string cUrl {get;set;}
    private static string  caminhoDownload {get;set;}

    static async Task Main(string[] args){
        IUrlValidator urlValidator = new Urlvalidator();
        IYoutubeService youtubeService = new YoutubeService();

        Console.Write("URL do vídeo.: ");
        cUrl = Console.ReadLine() ?? ""; //Lendo a URL que foi colada.

        if(!urlValidator.IsValidUrl(cUrl)){
            Console.WriteLine("URL inválida. Tente novamente.");
            return;
        }

        if(String.IsNullOrEmpty(caminhoDownload)){
            Console.Write("Pasta destino: ");
            caminhoDownload = Console.ReadLine() ?? "";
        }
        try{
            await youtubeService.BaixarAudioAsync(cUrl, caminhoDownload);
            Console.Write("Download Concluído com sucesso !");
        }
        catch(Exception ex){
            Console.WriteLine($"Erro ao baixar o áudio: {ex.Message}");
        }

    }
}