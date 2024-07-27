namespace videodownloader.Models
{
    public interface IVideoDownload
    {
        Task<string> DownloadVideoAsync(string VideoUrl);
    }
}
