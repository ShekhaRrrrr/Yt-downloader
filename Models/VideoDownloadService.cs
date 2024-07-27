using System.IO;
using System.Threading.Tasks;
using videodownloader.Models;
using VideoLibrary;

public class VideoDownloadService : IVideoDownload
{
    public async Task<string> DownloadVideoAsync(string videoUrl)
    {
        var youtube = YouTube.Default;
        var video = await youtube.GetVideoAsync(videoUrl);
        string videoPath = Path.Combine(Path.GetTempPath(), video.FullName);

        await File.WriteAllBytesAsync(videoPath, await video.GetBytesAsync());

        return videoPath;
    }
}

